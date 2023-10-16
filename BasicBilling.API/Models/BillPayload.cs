

namespace BasicBilling.API.Models;
public class BillPayload
{
    public long? ClientId { get; set; }
    public required string Category { get; set; }
    public required string Period { get; set; }
}