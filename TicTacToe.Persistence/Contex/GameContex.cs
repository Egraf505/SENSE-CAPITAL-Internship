using Microsoft.EntityFrameworkCore;
using TicTacToe.Domain;
using TicTacToe.Persistence.EntityConfigurations;

namespace TicTacToe.Persistence.Contex
{
    public class GameContex : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GameTable> GameTables { get; set; }

        public GameContex()
        {

        }

        public GameContex(DbContextOptions<GameContex> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Gamesdb;Username=postgres;Password=EfgraF_0256");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameTableConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
