using System.Data.Entity;
using _1er_logiciel_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1er_logiciel_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    BookController(AppDbContext context) => this._context = context;

    [HttpGet(Name = "GetBook")]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _context.Books.ToListAsync();
    }
}
