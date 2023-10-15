using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Models;

[Index(nameof(Category), nameof(Period), nameof(ClientId))]
public class Bill
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public long Id { get; set; }
    public required string Category { get; set; }
    public required string Period { get; set; }
    public bool Status { get; set; }
    public required long ClientId { get; set; }
}