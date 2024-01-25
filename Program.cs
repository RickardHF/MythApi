using Microsoft.EntityFrameworkCore;
using MythApi.Gods.Interfaces;
using MythApi.Gods.DBRepositories;
using MythApi.Gods.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IGodRepository, GodRepository>();

var app = builder.Build();

app.RegisterGodEndpoints();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
