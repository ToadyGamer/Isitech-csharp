using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Models;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books {get; set;} = default!; //Liste des livres dans la BDD
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDir = Directory.GetCurrentDirectory(); //On récupère le dossier dans lequel on est
        var dbPath = Path.Combine(currentDir, "Books.db"); //On créer la bonne path pour accéder ou créer le fichier en rajoutant son nom et extension
        optionsBuilder.UseSqlite($"Filename={dbPath}"); //On ouvre ou créer le dosiser
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Lors de la création du model
    {
        modelBuilder.Entity<Book>().HasData( //On ajoute des données ayant le type "Book" avec les données suivantes

            new Book
            {
                Id = 2,
                Title = "Professional C# 7 and .NET Core 2.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2018, 04, 18)
            },
            new Book
            {
                Id = 3,
                Title = "Professional C# 8 and .NET Core 3.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2019, 10, 30)
            },
            new Book
            {
                Id = 4,
                Title = "Professional C# 9 and .NET 5",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2021, 01, 01)
            },
            new Book
            {
                Id = 5,
                Title = "Beginning Visual C# 2019",
                Author = "Perkins, Reid, and Hammer",
                Description = "The perfect guide to Visual C#",
                Genre = "Software",
                Price = 45,
                PublishDate = new DateTime(2020, 09, 23)
            },
            new Book
            {
                Id = 6,
                Title = "Pro C# 7",
                Author = "Andrew Troelsen",
                Description = "The ultimate C# resource",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2017, 10, 01)
            },
            new Book
            {
                Id = 7,
                Title = "Professional C# 6 and .NET Core 1.0",
                Author = "Christian Nagel",
                Description = "A true masterclass in C# and .NET programming",
                Genre = "Software",
                Price = 50,
                PublishDate = new DateTime(2016, 05, 09)
            });
    }
}