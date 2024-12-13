using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/book")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;
    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = _context.Books.ToList();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        Book? book = _context.Books.FirstOrDefault(x => x.id == id);

        if (book == null)
        {
            return NotFound($"Book with ID {id} not found.");
        }

        return Ok(book);
    }
    
    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetBookById), new { id = book.id }, book);
    }

    [HttpPut]
    public IActionResult ModifyBook(Book book){
        Book? dbBook = _context.Books.FirstOrDefault(x => x.id == book.id);
        if(dbBook == null)
        {
            return NotFound($"Book with ID {book.id} not found.");
        }
        dbBook.Code = book.Code;
        dbBook.Titre = book.Titre;
        dbBook.Genre = book.Genre;
        dbBook.Image = book.Image;
        dbBook.IdAuteur = book.IdAuteur;

        _context.SaveChanges();
        return Ok(dbBook);
    }
}