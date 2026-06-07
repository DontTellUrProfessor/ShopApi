using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Users
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Username).IsRequired().HasMaxLength(30);
            e.Property(x => x.Email).IsRequired().HasMaxLength(150);
            e.Property(x => x.PasswordHash).IsRequired().HasMaxLength(150);
            e.Property(x => x.CreatedAt).IsRequired().HasColumnType("date");
            
        });

        // Products
        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(300);
            e.Property(x => x.Description).HasColumnType("nvarchar(max)");
            e.Property(x => x.Price).IsRequired().HasColumnType("double");
            e.Property(x => x.StockQuantity).IsRequired();
        });

        // Order
        modelBuilder.Entity<Order>(e =>
        {
            e.HasKey(x => x.OrderId);
            e.Property(x => x.OrderDate).HasColumnType("DateTime");
            e.Property(x => x.Status).IsRequired().HasMaxLength(30);
            e.Property(x => x.TotalAmount).HasColumnType("double");
            
            e.HasMany(x => x.Payments)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        });

        // OrderItem
        modelBuilder.Entity<OrderItem>(e =>
        {
            e.HasKey(x => new { x.OrderId, x.ProductId });
            e.Property(x => x.Quantity).HasColumnType("real");
            e.Property(x => x.Price).HasColumnType("real");
            
            e.HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductId);
            
            e.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);
        });
        
        
        // Payment
        modelBuilder.Entity<Payment>(e =>
        {
            e.HasKey(x => x.PaymentId);
            e.Property(x => x.Amount).IsRequired().HasColumnType("real");

            e.HasOne(x => x.Order)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.OrderId);;
        });
        
        
    }
}