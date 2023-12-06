using System.Data.Common;
using _1er_logiciel_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    //TODO : Respecter le standart REST
    private readonly AppDbContext _context; //Créer la référence de AppDbContext afin de pouvoir l'utiliser

    public BookController(AppDbContext context)
    {
        _context = context; //Assigniation du context
    }

    [HttpGet] //Affichage en format GET pour l'HTML
    public async Task<IEnumerable<Book>> Get() //Fonction pour afficher TOUS les libres
    {
        return await _context.Books.ToListAsync(); //On retourne TOUS les livres qui sont présent dans le context actuel en attendant que la requete soit finis avec le async
    }

    // GET: api/Book/[id]
    [HttpGet("{id}", Name = nameof(GetBook))] //Affichage en format GET pour l'HTML avec en input un ID
    public async Task<ActionResult<Book>> GetBook(int id)  //Fonction pour afficher UN livre a partir de son ID
    {
        var book = await _context.Books.FindAsync(id); //On cherche un livre avec un ID spécifique
        if (book == null) return NotFound(); //Si on ne trouve pas de livre, alors on retourne que l'on a rien trouvé

        return book; //Sinon on retourne le livre trouvé
    }

    // POST: api/Book
    [HttpPost] //Affichage en format POST pour l'HTML
    [ProducesResponseType(201, Type = typeof(Book))] //Pour le dev : Affichage de la réussite et de la création d'un book
    [ProducesResponseType(400)] //Pour le dev : Affichage d'une mauvaise requete
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book) //Fonction qui permet de créer un livre avec dans le body un libre a remplir
    {
        if (book == null) return BadRequest(); //Si le livre créer manque d'information (si il n'arrive pas a etre créer), alors on envoie un erreur pour le client

        Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title); //On regarde si il existe deja un libre avec le même nom pour éviter les doublons
        if (addedBook != null)return BadRequest("Book already exists"); //Si on trouve un book, alors on return que le livre existe deja 
        else
        {
            await _context.Books.AddAsync(book); //On ajoute le livre dans le body dans les livres
            await _context.SaveChangesAsync(); //On sauvegarde les changements

            return CreatedAtRoute( //On retourne une route pour savoir ce qui ce passe
                routeName: nameof(GetBook), //Le nom de la route
                routeValues: new { id = book.Id }, //L'id qui est créer
                value: book); //Les informations du livre que l'on a ajouter

        }
    }

    // MODIFICATION
    [HttpPut("{id},title, author, genre, price, publishDate, description, remarks", Name = nameof(PUTBook))]
    public async Task<ActionResult<Book>> PUTBook(int id, string ?title, string ?author, string ?genre, decimal price, DateTime publishDate, string ?description, string ?remarks)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        Book newbook = book;
        if(title != null) newbook.Title = title;
        if(author != null) newbook.Author = author;
        if(genre != null) newbook.Genre = genre;
        if(price != null) newbook.Price = price;
        if(publishDate != null) newbook.PublishDate = publishDate;
        if(description != null) newbook.Description = description;
        if(remarks != null) newbook.Remarks = remarks;
        await _context.SaveChangesAsync();

        return newbook;
    }

    // AJOUT (2eme facon avec les différents éléments à rentré)
    [HttpPost("title, author, genre, price, publishDate, description, remarks", Name = nameof(POSTBook))]
    [ProducesResponseType(201, Type = typeof(Book))] //Affichage de la réussite et de la création d'un book
    [ProducesResponseType(400)] //Affichage d'une mauvaise requete
    public async Task<ActionResult<Book>> POSTBook(int id, string ?title, string ?author, string ?genre, decimal price, DateTime publishDate, string ?description, string ?remarks)
    {
        if(price == null || publishDate == null) return BadRequest();

        Book newbook = new Book();
        if(title != null) newbook.Title = title;
        if(author != null) newbook.Author = author;
        if(genre != null) newbook.Genre = genre;
        if(price != null) newbook.Price = price;
        if(publishDate != null) newbook.PublishDate = publishDate;
        if(description != null) newbook.Description = description;
        if(remarks != null) newbook.Remarks = remarks;
        await _context.Books.AddAsync(newbook);
        await _context.SaveChangesAsync();

        return newbook;
    }

    // SUPPRESSION: api/Book/[id]
    [HttpDelete("{id}", Name = nameof(DELETEBook))]
    public async Task<ActionResult<Book>> DELETEBook(int id)
    {
        Book? existantBook = await _context.Books.FindAsync(id);
        if (existantBook == null) return NotFound();
        else
        {
            // we remove the book to the database
            _context.Books.Remove(existantBook);
            await _context.SaveChangesAsync();
        }

        return NoContent();
    }
}
