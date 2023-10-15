using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.Models;

public class ClientContext : DbContext
{
    public string DbPath { get; }
    public DbSet<Client> ClientItems { get; set; } = null!;
    public DbSet<Bill> BillItems { get; set; } = null!;
    public ClientContext(DbContextOptions<ClientContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "BasicBilling.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>()
            .Property(b => b.Status)
            .HasDefaultValue(false);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}