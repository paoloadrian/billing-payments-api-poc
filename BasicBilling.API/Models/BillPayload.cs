

namespace BasicBilling.API.Models;
public class BillPayload
{
    public required string Type { get; set; }
    public required string Month { get; set; }
}