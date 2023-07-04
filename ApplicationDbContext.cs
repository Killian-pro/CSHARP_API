using APIApp;
using Microsoft.EntityFrameworkCore;


namespace MyApi.Context
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Categorie>()
                        .Property(c => c.CategoryName)
                        .IsRequired()
                        .HasMaxLength(15);
            modelBuilder.Entity<Categorie>()
                .HasKey(c => c.CategoryId)
                .HasName("PrimaryKey_Categories");

            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductId)
                .HasName("PrimaryKey_Products");
        }

    }
}