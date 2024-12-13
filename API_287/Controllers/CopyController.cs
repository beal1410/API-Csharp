using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/copy")]
public class CopyController : ControllerBase
{
    private readonly AppDbContext _context;

    public CopyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCopies()
    {
        var copies = _context.Copies.ToList();
        return Ok(copies);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCopyById(int id)
    {
        Copy? copy = _context.Copies.FirstOrDefault(x => x.id == id);

        if (copy == null)
        {
            return NotFound($"Copy with ID {id} not found.");
        }

        return Ok(copy);
    }

    [HttpPost]
    public IActionResult CreateCopy(Copy copy)
    {
        _context.Copies.Add(copy);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCopyById), new { id = copy.id }, copy);
    }

    [HttpPut]
    public IActionResult ModifyCopy(Copy copy){
        Copy? dbCopy = _context.Copies.FirstOrDefault(x => x.id == copy.id);
        if(dbCopy == null)
        {
            return NotFound($"Copy with ID {copy.id} not found.");
        }
        dbCopy.EtatDuLivre = copy.EtatDuLivre;
        dbCopy.IdLivre = copy.IdLivre;

        _context.SaveChanges();
        return Ok(dbCopy);
    }
}