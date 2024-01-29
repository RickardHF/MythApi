using Microsoft.EntityFrameworkCore;
using MythApi.Gods.Interfaces;
using MythApi.Gods.DBRepositories;
using MythApi.Common.Database;
using MythApi.Endpoints.v1;
using MythApi.Mythologies.DBRepositories;
using MythApi.Mythologies.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services
    .AddScoped<IGodRepository, GodRepository>()
    .AddScoped<IMythologyRepository, MythologyRepository>();

var app = builder.Build();

app.RegisterGodEndpoints();
app.RegisterMythologiesEndpoints();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();
