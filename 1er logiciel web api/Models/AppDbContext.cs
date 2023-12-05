using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Models;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books {get; set;}
    //Sert a se co à la BDD (info connexion, nom BDD, liens, ect)
    //private const string ConnectionString = @"Server=http://localhost:5222;Database=BookDb;Trusted_Connection=true;";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Filename=C:/sqlite/Book.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(b => b.Id).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Title);
        modelBuilder.Entity<Book>().Property(b => b.Author);
        modelBuilder.Entity<Book>().Property(b => b.Genre);
        modelBuilder.Entity<Book>().Property(b => b.Price).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.PublishDate).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Description);
        modelBuilder.Entity<Book>().Property(b => b.Remarks);
    }
}