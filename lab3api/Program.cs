using lab3api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:ProductConnection"]);
opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllers();
builder.Services.AddRateLimiter(opts => {
opts.AddFixedWindowLimiter("fixedWindow", fixOpts => {
fixOpts.PermitLimit = 1;
fixOpts.QueueLimit = 0;
fixOpts.Window = TimeSpan.FromSeconds(15);
});
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseRateLimiter();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
var context = app.Services.CreateScope().ServiceProvider.
    GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);
app.Run();

