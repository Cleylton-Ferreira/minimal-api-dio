using MinimalApi.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddHttpClient("FruitAPI", httpClient =>{
    httpClient.BaseAddress = new Uri("wss://api.coinext.com.br/WSGateway/");
});

var app = builder.Build();

app.MapGet("/", () => "Olá pessoal");

app.MapPost("/login", (LoginDTO loginDTO) => 
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login feito com sucesso!!");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();




