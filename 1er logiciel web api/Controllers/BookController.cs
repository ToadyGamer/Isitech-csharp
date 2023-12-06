using _1er_logiciel_web_api.Models;
using AutoMapper;
using AutoMapperDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    //TODO : Respecter le standart REST
    private readonly AppDbContext _context; //Créer la référence de AppDbContext afin de pouvoir l'utiliser
    private readonly IMapper _mapper;

    public BookController(AppDbContext context, IMapper mapper)
    {
        _context = context; //Assigniation du context
        _mapper = mapper;
    }

    // TODO: PUT: api/Book/[id] creer la route qui permet de mettre a jour un livre existant
    // TODO: utilisez des annotations pour valider les donnees entrantes avec ModelState
    // TODO: utilisez le package AutoMapper pour mapper les donnees de BookUpdateDTO vers Book
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
            //MODELESTATE

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
    public async Task<ActionResult<BookUpdateDTO>> PUTBook(int id, string ?title, string ?author, string ?genre, decimal ?price, DateTime ?publishDate, string ?description, string ?remarks)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        var mapper = MapperConfig.InitializeAutomapper();

        var newbook = mapper.Map<Book, BookUpdateDTO>(book);

        if(title != null) newbook.Title = title;
        if(author != null) newbook.Author = author;
        if(genre != null) newbook.Genre = genre;
        if(price != null) newbook.Price = (decimal)price;
        if(publishDate != null) newbook.PublishDate = (DateTime)publishDate;
        if(description != null) newbook.Description = description;
        if(remarks != null) newbook.Remarks = remarks;
        await _context.SaveChangesAsync();

        return newbook;
    }

    // AJOUT (2eme facon avec les différents éléments à rentré)
    [HttpPost("title, author, genre, price, publishDate, description, remarks", Name = nameof(POSTBook))]
    [ProducesResponseType(201, Type = typeof(Book))] //Affichage de la réussite et de la création d'un book
    [ProducesResponseType(400)] //Affichage d'une mauvaise requete
    public async Task<ActionResult<Book>> POSTBook(int id, string ?title, string ?author, string ?genre, decimal ?price, DateTime ?publishDate, string ?description, string ?remarks)
    {
        if(price == null || publishDate == null) return BadRequest();

        Book newbook = new Book();
        if(title != null) newbook.Title = title;
        if(author != null) newbook.Author = author;
        if(genre != null) newbook.Genre = genre;
        if(price != null) newbook.Price = (decimal)price;
        if(publishDate != null) newbook.PublishDate = (DateTime)publishDate;
        if(description != null) newbook.Description = description;
        if(remarks != null) newbook.Remarks = remarks;
        await _context.Books.AddAsync(newbook);
        await _context.SaveChangesAsync();

        return newbook;
    }

    // SUPPRESSION: api/Book/[id]
    [HttpDelete("{id}", Name = nameof(DELETEBook))] //Affichage en format DELETE pour l'HTML
    public async Task<ActionResult<Book>> DELETEBook(int id) //Fonction qui permet de supprimer un livre avec en parametre un ID
    {
        Book? existantBook = await _context.Books.FindAsync(id); //On cherche si un livre existe
        if (existantBook == null) return NotFound(); //Si on en trouve pas, on annonce que l'on en a pas trouvé
        else
        {
            _context.Books.Remove(existantBook); //Sinon on supprime le livre
            await _context.SaveChangesAsync(); //Et on sauvegarde les données
        }

        return NoContent(); //Puis on retourne
    }
}
