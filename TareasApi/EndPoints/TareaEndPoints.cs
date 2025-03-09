using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TareasApi.Data;


namespace TareasApi.EndPoints
{
    public static class TareaEndPoints
    {
        //public static RouteGroupBuilder MapTareaEndPoints( this RouteGroupBuilder group)
        //{
        //    group.MapGet("/", async (TareasDbContext db) =>
        //                {
        //                    return await db.Tarea.ToListAsync();
        //                });

        //    group.MapGet("/{id}", async (int id, TareasDbContext db) =>
        //    {
        //        return await db.Tarea.FindAsync(id)
        //            is Tarea tarea
        //                ? Results.Ok(tarea)
        //                : Results.NotFound();
        //    });
        //    group.MapPost("/", async (Tarea tarea, TareasDbContext db) =>
        //    {
        //        if (tarea is null)
        //            return Results.BadRequest();

        //        db.Tarea.Add(tarea);
        //        await db.SaveChangesAsync();
        //        return Results.Created($"/api/tarea/{tarea.Id_Tarea}", tarea);
        //    });
        //    group.MapPut("/{id}", async (int id, Tarea inputTarea, TareasDbContext db) =>
        //    {

        //        var tarea = await db.Tarea.FindAsync(id);
        //        if (tarea is null) return Results.NotFound();
        //        tarea.Descripcion = inputTarea.Descripcion;
        //        await db.SaveChangesAsync();
        //        return Results.NoContent();
        //    });
        //    group.MapDelete("/{id}", async (int id, TareasDbContext db) =>
        //    {
        //        var tarea = await db.Tarea.FindAsync(id);
        //        if (tarea is null) return Results.NotFound();
        //        db.Tarea.Remove(tarea);
        //        await db.SaveChangesAsync();
        //        return Results.NoContent();
        //    });
        //    return group;
        //}
    }
}
