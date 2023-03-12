using Microsoft.EntityFrameworkCore;
using TicTacToe.Domain;
using TicTacToe.Persistence.EntityConfigurations;

namespace TicTacToe.Persistence.Contex
{
    public class GameContex : DbContext
   {
        public DbSet<GameTable> GameTables { get; set; }

        public GameContex()
        {
            Database.EnsureCreated();
        }

        public GameContex(DbContextOptions<GameContex> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Gamesdb;Username=postgres;Password=EfgraF_0256");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameTableConfiguration());           

            base.OnModelCreating(builder);
        }
    }
}
