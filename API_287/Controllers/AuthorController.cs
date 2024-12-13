using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/author")]
public class AuthorController : ControllerBase
{
    private readonly AppDbContext _context;
    public AuthorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBills()
    {
        var authors = _context.Authors.ToList();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        Author? author = _context.Authors.FirstOrDefault(x => x.id == id);

        if (author == null)
        {
            return NotFound($"Author with ID {id} not found.");
        }

        return Ok(author);
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAuthorById), new { id = author.id }, author);
    }

    [HttpPut]
    public IActionResult ModifyAuthor(Author author){
        Author? dbAuthor = _context.Authors.FirstOrDefault(x => x.id == author.id);
        if(dbAuthor == null)
        {
            return NotFound($"Author with ID {author.id} not found.");
        }
        dbAuthor.Nom = author.Nom;

        _context.SaveChanges();
        return Ok(dbAuthor);
    }
}