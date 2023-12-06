using System.Data.Common;
using _1er_logiciel_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context; //Obtenir la référence de AppDbContext afin de ne pas avoir de doublons de référence

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
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // POST: api/Book
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

        return existantBook;
    }
}
