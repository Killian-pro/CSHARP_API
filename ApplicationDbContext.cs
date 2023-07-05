using APIApp;
using Microsoft.EntityFrameworkCore;


namespace MyApi.Context
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .HasKey(c => c.Id)
                .HasName("PrimaryKey_Player");

            modelBuilder.Entity<Game>()
                .HasKey(p => p.Id)
                .HasName("PrimaryKey_Game");

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Name)
                .IsUnique();

        }

    }
}