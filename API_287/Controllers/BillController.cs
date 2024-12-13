using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/bill")]
public class BillController : ControllerBase
{
    private readonly AppDbContext _context;

    public BillController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBills()
    {
        var bills = _context.Bills.ToList();
        return Ok(bills);
    }

    [HttpGet("{id}")]
    public IActionResult GetBillById(int id)
    {
        Bill? bill = _context.Bills.FirstOrDefault(x => x.id == id);

        if (bill == null)
        {
            return NotFound($"Bill with ID {id} not found.");
        }

        return Ok(bill);
    }

    [HttpPost]
    public IActionResult CreateBill(Bill bill)
    {
        _context.Bills.Add(bill);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetBillById), new { id = bill.id }, bill);
    }
    
    [HttpPut]
    public IActionResult ModifyBill(Bill bill){
        Bill? dbBill = _context.Bills.FirstOrDefault(x => x.id == bill.id);
        if(dbBill == null)
        {
            return NotFound($"Bill with ID {bill.id} not found.");
        }
        dbBill.FraisPaye = bill.FraisPaye;
        dbBill.Date = bill.Date;
        dbBill.IdEmprunt = bill.IdEmprunt;

        _context.SaveChanges();
        return Ok(dbBill);
    }
}