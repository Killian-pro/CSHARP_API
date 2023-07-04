using static System.Console;
using Microsoft.EntityFrameworkCore;
namespace EFCore.Shared;

public class NorthwindApi : DbContext
{
    public DbSet<Categorie>? Categories { get; set; }
    // public DbSet<Products> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

        string connection = $"Filename={path}";

        ConsoleColor color = Console.ForegroundColor;
        WriteLine($"Connection string: {connection}");
        optionsBuilder.UseSqlite(connection);

    }
}





