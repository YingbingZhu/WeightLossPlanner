using Scalar.AspNetCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WeightLossPlannerAPI.Data;
using WeightLossPlannerAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configure EF Core with Azure SQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Register the custom OpenAPI XML comments middleware.
// The XML file is assumed to be in the output folder and named after the assembly.
// var xmlFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
// app.UseMiddleware<OpenApiXmlCommentsMiddleware>(xmlFilePath);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
        .WithTheme(ScalarTheme.Moon)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
