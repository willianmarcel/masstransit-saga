using Microsoft.EntityFrameworkCore;
using CustomerApi.Model;
using System.Reflection;

namespace CustomerApi.Infrastructure;

public class CustomerDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public CustomerDbContext()
    {

    }

    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
