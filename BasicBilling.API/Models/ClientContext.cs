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
        
        var clientData = new List<Client>
        {
            new() { Id = 1, Name = "Joseph Carlton" },
            new() { Id = 2, Name = "Maria Juarez" },
            new() { Id = 3, Name = "Albert Kenny" },
            new() { Id = 4, Name = "Jessica Phillips" },
            new() { Id = 5, Name = "Charles Johnson" }
        };
        modelBuilder.Entity<Client>().HasData(clientData);
        
        var counter = 1;
        clientData.ForEach(client => {
            var billingData = new List<Bill>
            {
                new() { Id = counter, ClientId = client.Id, Type = "SEWER", Month = "202301", Status = false },
                new() { Id = counter + 1, ClientId = client.Id, Type = "WATER", Month = "202301", Status = false },
                new() { Id = counter + 2, ClientId = client.Id, Type = "ELECTRICITY", Month = "202301", Status = false },
                new() { Id = counter + 3, ClientId = client.Id, Type = "SEWER", Month = "202302", Status = false },
                new() { Id = counter + 4, ClientId = client.Id, Type = "WATER", Month = "202302", Status = false },
                new() { Id = counter + 5, ClientId = client.Id, Type = "ELECTRICITY", Month = "202302", Status = false },
            };
            modelBuilder.Entity<Bill>().HasData(billingData);
            counter += 6;
        });

    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}