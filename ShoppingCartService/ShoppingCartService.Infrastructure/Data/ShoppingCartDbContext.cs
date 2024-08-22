using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Domain.Entities;

namespace ShoppingCartService.Infrastructure.Data;

public class ShoppingCartDbContext : DbContext
{
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
    {
    }

    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>().ToTable("CartItems");
    }
}