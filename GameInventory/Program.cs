using GameInventory.Infrastructure.Persistance;
using GameInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

//sqlserver
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSqlServer<GameInventoryContext>(connectionString, options =>
{
   options.MigrationsAssembly(typeof(Program).Assembly.FullName);
});


builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo {
         Title = "GameInventory API",
         Description = "Inventory of games",
         Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameInventory API V1");
   });
}

app.MapGet("/games", async (GameInventoryContext db) => await db.Games.ToListAsync());

app.MapGet("/games/{id}", async (GameInventoryContext db, int id) => await db.Games.FindAsync(id));

app.MapPost("/games", async (GameInventoryContext db, Game game) =>
{
    await db.Games.AddAsync(game);
    await db.SaveChangesAsync();
    return Results.Created($"/game/{game.Id}", game);
});

app.MapPut("/games/{id}", async (GameInventoryContext db, Game updateGame, int id) =>
{
      var game = await db.Games.FindAsync(id);
      if (game is null) return Results.NotFound();
      game.Title = updateGame.Title ?? game.Title;
      game.PlatformId = updateGame.PlatformId;
      await db.SaveChangesAsync();
      return Results.NoContent();
});

app.MapDelete("/games/{id}", async (GameInventoryContext db, int id) =>
{
   var game = await db.Games.FindAsync(id);
   if (game is null)
   {
      return Results.NotFound();
   }
   db.Games.Remove(game);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.Run();
