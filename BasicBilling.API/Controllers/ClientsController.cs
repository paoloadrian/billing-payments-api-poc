// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicBilling.API.Models;

namespace BasicBilling.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ClientContext _context;

    public ClientsController(ClientContext context)
    {
        _context = context;
    }

    // GET: Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClientItems()
    {
        if (_context.ClientItems == null)
        {
            return NotFound();
        }
        return await _context.ClientItems.ToListAsync();
    }

    // GET: Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(long id)
    {
        if (_context.ClientItems == null)
        {
            return NotFound();
        }
        var client = await _context.ClientItems.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    // PUT: Clients/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(long id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClientExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: Clients
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(ClientPayload clientPayload)
    {
        if (_context.ClientItems == null)
        {
            return Problem("Entity set 'ClientContext.ClientItems'  is null.");
        }
        var client = new Client { Name = clientPayload.Name };
        _context.ClientItems.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    // DELETE: Clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(long id)
    {
        if (_context.ClientItems == null)
        {
            return NotFound();
        }
        var client = await _context.ClientItems.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.ClientItems.Remove(client);
        await _context.SaveChangesAsync();

        if (_context.BillItems != null)
        {
            var bills = await _context.BillItems.Where(e => e.ClientId == id).ToListAsync();
            
            if (bills != null)
            {
                _context.BillItems.RemoveRange(bills);
                await _context.SaveChangesAsync();
            }
        }

        return NoContent();
    }

    private bool ClientExists(long id)
    {
        return (_context.ClientItems?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
