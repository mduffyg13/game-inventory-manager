using GameInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//sqlserver
var connectionString = builder.Configuration.GetConnectionString("Games");

builder.Services.AddEndpointsApiExplorer();

//in memory db
//builder.Services.AddDbContext<GameDb>(options => options.UseInMemoryDatabase("items"));
//persistance
builder.Services.AddSqlServer<GameDb>(connectionString);
//builder.Services.AddNpgsql<GameDb>(connectionString);

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

app.MapGet("/games", async (GameDb db) => await db.Games.ToListAsync());

app.MapGet("/games/{id}", async (GameDb db, int id) => await db.Games.FindAsync(id));

app.MapPost("/games", async (GameDb db, Game game) =>
{
    await db.Games.AddAsync(game);
    await db.SaveChangesAsync();
    return Results.Created($"/game/{game.Id}", game);
});

app.MapPut("/games/{id}", async (GameDb db, Game updateGame, int id) =>
{
      var game = await db.Games.FindAsync(id);
      if (game is null) return Results.NotFound();
      game.Name = updateGame.Name ?? game.Name;
      game.Platform = updateGame.Platform ?? game.Platform;
      await db.SaveChangesAsync();
      return Results.NoContent();
});

app.MapDelete("/games/{id}", async (GameDb db, int id) =>
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
