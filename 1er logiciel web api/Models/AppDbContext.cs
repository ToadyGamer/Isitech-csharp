using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Models;

public class AppDbContext : DbContext
{
    //Sert a se co à la BDD (info connexion, nom BDD, liens, ect)
    //private const string ConnectionString = @"Server=http://localhost:5222;Database=BookDb;Trusted_Connection=true;";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Filename=C:/sqlite/Book.db");
    }

    public void LogAPI(){

    }
    public DbSet<Book> Books {get; set;}
}