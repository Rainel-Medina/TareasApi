using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TareasApi.EndPoints;
using CapaNegocio.Interfaces;
using CapaNegocio.Clases;
using TareasApi.Infraestructura.Repositories;
using CapaDatos.Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


//configurar el acceso a Datos
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Fixing the errors by removing the extra dot and ensuring the method call is correct
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


//var conn = builder.Configuration.GetConnectionString("AppConnection");
//builder.Services.AddDbContext<TareasContext>(options =>
//    options.UseSqlServer(conn));

////configurar las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<ITarea, LogicaTarea>();
builder.Services.AddScoped<IUsuarios, LogicaUsuarios>();
builder.Services.AddScoped<ICategoria, LogicaCategoria>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapTareaEndPoints();
//app.MapGroup("/api/tarea").MapTareaEndPoints();

app.Run();
