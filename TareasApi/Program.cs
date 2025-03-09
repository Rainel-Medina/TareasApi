using CapaDatos;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TareasApi.Data;
using TareasApi.EndPoints;
using CapaNegocio.Interfaces;
using CapaNegocio.Clases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//configurar el acceso a Datos
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var conn = builder.Configuration.GetConnectionString("AppConnection");
//builder.Services.AddDbContext<TareasContext>(options =>
//    options.UseSqlServer(conn));

////configurar las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<ITarea, LogicaTarea>();
builder.Services.AddScoped<IUsuarios, LogicaUsuarios>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapTareaEndPoints();
//app.MapGroup("/api/tarea").MapTareaEndPoints();

app.Run();
