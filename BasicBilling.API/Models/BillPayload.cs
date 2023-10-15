

namespace BasicBilling.API.Models;
public class BillPayload
{
    public required string Category { get; set; }
    public required string Period { get; set; }
}