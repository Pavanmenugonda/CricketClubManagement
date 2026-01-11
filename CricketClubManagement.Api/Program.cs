//using CricketClubManagement.Api.Middleware;
using CricketClubManagement.Application.Interfaces;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models; // Add this using directive
using Swashbuckle.AspNetCore.SwaggerGen; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CricketClubManagementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CricketClubManagementDatabase"),
        sql => sql.MigrationsAssembly("CricketClubManagement.Infrastructure") // point to Infrastructure
        ));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ISeasonService, SeasonService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:58232")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseCors("AllowAngular");

app.MapControllers();

app.Run();


// For integration testing purposes
public partial class Program { }