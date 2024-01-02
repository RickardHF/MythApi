using MythApi.Gods.Interfaces;
using MythApi.Gods.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGodRepository, GodRepository>();

var app = builder.Build();

app.RegisterGodEndpoints();

app.Run();
