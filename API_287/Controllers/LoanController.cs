using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/loan")]
public class LoanController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoanController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Getloans()
    {
        var loans = _context.Loans.ToList();
        return Ok(loans);
    }

    [HttpGet("{id}")]
    public IActionResult GetLoanById(int id)
    {
        Loan? loan = _context.Loans.FirstOrDefault(u => u.id == id);

        if (loan == null)
        {
            return NotFound($"Loan with ID {id} not found.");
        }

        return Ok(loan);
    }

    [HttpPost]
    public IActionResult CreateLoan(Loan loan)
    {
        _context.Loans.Add(loan);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetLoanById), new { id = loan.id }, loan);
    }
    [HttpPut]
    public IActionResult ModifyLoan(Loan loan){
        Loan? dbLoan = _context.Loans.FirstOrDefault(x => x.id == loan.id);
        if(dbLoan == null)
        {
            return NotFound($"Loan with ID {loan.id} not found.");
        }
        dbLoan.DateEmprunt = loan.DateEmprunt;
        dbLoan.DateRetourPrev = loan.DateRetourPrev;
        dbLoan.DateRetourReel = loan.DateRetourReel;
        dbLoan.IdExemplaire = loan.IdExemplaire;

        _context.SaveChanges();
        return Ok(dbLoan);
    }

}