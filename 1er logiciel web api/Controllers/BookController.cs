using System.Data.Entity;
using _1er_logiciel_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _context.Books.ToListAsync();
    }

    // GET: api/Book/[id]
    [HttpGet("{id}", Name = nameof(GetBook))]
    public async Task<ActionResult<Book>> GetBook(int idBook)
    {
        var book = await _context.Books.FindAsync(idBook);
        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // POST: api/Book
    // BODY: Book (JSON)
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        // we check if the parameter is null
        if (book == null)
        {
            return BadRequest();
        }
        // we check if the book already exists
        Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (addedBook != null)
        {
            return BadRequest("Book already exists");
        }
        else
        {
            // we add the book to the database
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            // we return the book
            return CreatedAtRoute(
                routeName: nameof(GetBook),
                routeValues: new { id = book.Id },
                value: book);

        }
    }

    // TODO: PUT: api/Book/[id] creer la route qui permet de mettre a jour un livre existant

    // TODO: DELETE: api/Book/[id] creer la route qui permet de supprimer un livre existant


}
