using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Services;

public class BillService : IBillService
{
    private readonly ClientContext _context;

    public BillService(ClientContext context)
    {
        _context = context;
    }

    public async Task<List<Bill>> GetBillsAsync()
    {
        return await _context.BillItems.ToListAsync();
    }

    public async Task<List<Bill>> GetClientBillsAsync(long clientId)
    {
        return await _context.BillItems.Where(bill => bill.ClientId.Equals(clientId)).ToListAsync();
    }

    public async Task AddBillsAsync(string period, string category)
    {
        foreach (var client in _context.ClientItems)
        {
            var newBill = new Bill { Category = category, Period = period, ClientId = client.Id, Status = false };
            _context.BillItems.Add(newBill);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddClientBillAsync(string period, string category, long clientId)
    {
        var newBill = new Bill { Category = category, Period = period, ClientId = clientId, Status = false };
        _context.BillItems.Add(newBill);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> PayBillAsync(long id)
    {
        var bill = _context.BillItems?.Find(id);
        if (bill != null) {
            bill.Status = true;
            _context.Entry(bill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}