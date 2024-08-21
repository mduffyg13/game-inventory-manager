using GameInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameInventory.Infrastructure.Persistance
{
    class GameInventoryContext : DbContext
    {   
        public GameInventoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Series> Series { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "PS1" },
                new Platform { Id = 2, Name = "PS2" },
                new Platform { Id = 3, Name = "PS3" },
                new Platform { Id = 4, Name = "PS4" },
                new Platform { Id = 5, Name = "Nintendo Switch" },
                new Platform { Id = 6, Name = "PC" }
            );

            modelBuilder.Entity<Series>().HasData(
                new Series { Id = 1, Name = "Super Mario" },
                new Series { Id = 2, Name = "Ledgend Of Zelda" }
            );

            modelBuilder.Entity<Store>().HasData(
                new Store { Id = 1, Name = "Steam" },
                new Store { Id = 2, Name = "Epic" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Title = "Alan Wake 2", Format = "Digital", PlatformId = 6, StoreId = 2 },
                new Game { Id = 2, Title = "Dark Chronicle", Format = "Physical", PlatformId = 2 },
                new Game { Id = 3, Title = "Legend of Zelda: Breath of the Wild", Format = "Physical", PlatformId = 5, SeriesId = 2 },
                new Game { Id = 4, Title = "Super Mario Odyssey", Format = "Physical", PlatformId = 5, SeriesId = 1 }
            );
        }
    }
}