using Microsoft.EntityFrameworkCore;

namespace GameInventory.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Platform { get; set; }         
    }

    //todo split out
    class GameDb : DbContext
    {   
        public GameDb(DbContextOptions options) : base(options) { }
        public DbSet<Game> Games { get; set; } = null!;
    }
}