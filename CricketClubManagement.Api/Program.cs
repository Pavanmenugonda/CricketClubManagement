using CricketClubManagement.Infrastructure;
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

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
