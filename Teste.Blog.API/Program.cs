using BlogApi.Data;
using Microsoft.AspNet.SignalR.WebSockets;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using Teste.Blog.API.Notificacoes;
using Teste.Blog.Domain;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

builder.Services.AddInfrastructure();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione serviços ao contêiner.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseWebSockets();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocketHandler = context.RequestServices.GetRequiredService<NotificacoesHandler>();
        await webSocketHandler.Handle(context);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


