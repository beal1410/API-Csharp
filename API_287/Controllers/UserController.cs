using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public UserController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        User? user = _context.Users.FirstOrDefault(x => x.id == id);

        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        return Ok(user);
    }
    
    [HttpGet("{id}/address")]
    public IActionResult GetUserByIdWithAddress(int id){
        
        User? user = _context.Users.Include(x => x.Adresse).FirstOrDefault(x => x.id == id);

        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = user.id }, user);
    }

    [HttpPut]
    public IActionResult ModifyUser(User user){
        User? dbUser = _context.Users.FirstOrDefault(x => x.id == user.id);
        if(dbUser == null)
        {
            return NotFound($"User with ID {user.id} not found.");
        }
        dbUser.Prenom = user.Prenom;
        dbUser.Nom = user.Nom;
        dbUser.Telephone = user.Telephone;
        dbUser.Couriel = user.Couriel;
        dbUser.IdAdresse = user.IdAdresse;

        _context.SaveChanges();
        return Ok(dbUser);
    }


}