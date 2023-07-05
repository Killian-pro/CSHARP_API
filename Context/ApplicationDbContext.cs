using APIApp;
using Microsoft.EntityFrameworkCore;


namespace MyApi.Context
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player>? Player { get; set; } = null;
        public DbSet<Game>? Game { get; set; } = null;
        public DbSet<Score>? Scores { get; set; } = null;



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

            modelBuilder.Entity<Score>()
                .HasKey(p => p.Id)
                .HasName("PrimaryKey_Score");

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.Name)
                .IsUnique();

        }

    }
}