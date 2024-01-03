using MythApi.Gods.Interfaces;
using MythApi.Gods.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGodRepository, GodRepository>();

var app = builder.Build();

app.RegisterGodEndpoints();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
