using Microsoft.AspNetCore.Mvc;
using API_287.Models;
using API_287.Data;
using System.Linq;

[ApiController]
[Route("api/address")]
public class AddressController : ControllerBase
{
    private readonly AppDbContext _context;
    public AddressController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAddresses()
    {
        var addresses = _context.Addresses.ToList();
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address? address = _context.Addresses.FirstOrDefault(x => x.id == id);

        if (address == null)
        {
            return NotFound($"Address with ID {id} not found.");
        }

        return Ok(address);
    }

    [HttpPost]
    public IActionResult CreateAddress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { id = address.id }, address);
    }
  
    [HttpPut]
    public IActionResult ModifyAddress(Address address){
        Address? dbAddress = _context.Addresses.FirstOrDefault(x => x.id == address.id);
        if(dbAddress == null)
        {
            return NotFound($"Addresss with ID {address.id} not found.");
        }
        dbAddress.Rue = address.Rue;
        dbAddress.Ville = address.Ville;
        dbAddress.CodePostal = address.CodePostal;


        _context.SaveChanges();
        return Ok(dbAddress);
    }
}