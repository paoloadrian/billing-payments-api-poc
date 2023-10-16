using BasicBilling.API.Models;

namespace BasicBilling.API.Services;

public interface IBillService
{

    Task<List<Bill>> GetBillsAsync();
    Task<List<Bill>> GetClientBillsAsync(long clientId);
    Task AddBillsAsync(string period, string category);
    Task AddClientBillAsync(string period, string category, long clientId);
    Task<bool> PayBillAsync(long id);
}