using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Models;

[Index(nameof(Type), nameof(Month), nameof(ClientId))]
public class Bill
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public long Id { get; set; }
    public required string Type { get; set; }
    public required string Month { get; set; }
    public bool Status { get; set; }
    public required long ClientId { get; set; }
}