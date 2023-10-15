using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicBilling.API.Models;

namespace BasicBilling.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly ClientContext _context;

    public BillsController(ClientContext context)
    {
        _context = context;
    }

    // GET: Bills
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetBillItems([FromQuery(Name = "ClientId")] int ClientId)
    {
        if (_context.BillItems == null)
        {
            return NotFound();
        }
        if (ClientId != 0)
            return await _context.BillItems.Where(bill => bill.ClientId.Equals(ClientId)).ToListAsync();
        return await _context.BillItems.ToListAsync();
    }

    // POST: Bills
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bill>> PostBill(BillPayload billPayload)
    {
        if (_context.BillItems == null)
        {
            return Problem("Entity set 'ClientContext.BillItems'  is null.");
        }
        if (_context.ClientItems == null)
        {
            return Problem("Entity set 'ClientContext.ClientItems'  is null.");
        }
        foreach (var client in _context.ClientItems)
        {
            var newBill = new Bill { Category = billPayload.Category, Period = billPayload.Period, ClientId = client.Id, Status = false };
            _context.BillItems.Add(newBill);
            await _context.SaveChangesAsync();
        }

        return CreatedAtAction(nameof(GetBillItems), _context.BillItems);
    }

    // PUT: Bills/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754 
    [HttpPut("{id}")]
    public async Task<IActionResult> PayBill(long id)
    {
        if (_context.BillItems == null)
        {
            return Problem("Entity set 'ClientContext.BillItems'  is null.");
        }
        var bill = _context.BillItems?.Find(id);
        if (bill != null) {
            bill.Status = true;
            _context.Entry(bill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }

        return NoContent();
    }
}
