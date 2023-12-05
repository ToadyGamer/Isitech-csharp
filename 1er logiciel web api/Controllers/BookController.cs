using System.Data.Entity;
using _1er_logiciel_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;
    public BookController(AppDbContext context) => _context = context;

    [HttpGet(Name = "GetBook")]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _context.Books.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetBook")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if(book == null) return NotFound();
        return book;
    }

    // [HttpGet(Name = "PushBook")]
    // public async Task<IEnumerable<Book>> Push()
    // {
    //     //Faire le push
    //     return await _context.Books.ToListAsync();
    // }
}
