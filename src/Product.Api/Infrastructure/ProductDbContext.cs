﻿using Microsoft.EntityFrameworkCore;
using ProductApi.Model;
using System.Reflection;

namespace ProductApi.Infrastructure;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public ProductDbContext()
    {

    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
