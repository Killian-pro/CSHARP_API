using Microsoft.EntityFrameworkCore;


namespace MyApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Categorie> Categorie { get; set; }
    }
}