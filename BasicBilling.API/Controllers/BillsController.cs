using Microsoft.AspNetCore.Mvc;
using BasicBilling.API.Models;
using BasicBilling.API.Services;

namespace BasicBilling.API.Controllers;

[Route("[controller]")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly IBillService _billService;

    public BillsController(IBillService billService)
    {
        _billService = billService;
    }

    // GET: Bills
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetBillItems([FromQuery(Name = "ClientId")] long ClientId)
    {
        List<Bill> result;
        if (ClientId != 0)
            result = await _billService.GetClientBillsAsync(ClientId);
        else
            result = await _billService.GetBillsAsync();
        if (result.Count == 0)
        {
            return NotFound();
        }
        return result;
    }

    // POST: Bills
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bill>> PostBill(BillPayload billPayload)
    {
        if (billPayload.ClientId != null && billPayload.ClientId != 0)
        {
            await _billService.AddClientBillAsync(billPayload.Period, billPayload.Category, (long)billPayload.ClientId);
        }
        else
        {
            await _billService.AddBillsAsync(billPayload.Period, billPayload.Category);
        } 
        return Ok();
    }

    // PUT: Bills/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754 
    [HttpPut("{id}")]
    public async Task<IActionResult> PayBill(long id)
    {
        bool found = await _billService.PayBillAsync(id);
        if (!found)
        {
            return NotFound();
        }
        return Ok();
    }
}
