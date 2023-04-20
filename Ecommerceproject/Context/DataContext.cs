using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Ecommerceproject.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<ProductEntity>()
    //        .HasMany(p => p.Colours)
    //        .WithMany(c => c.Products)
    //        .UsingEntity(x => x.ToTable("ProductColour"));
    //}


    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<ColourEntity> Colours { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemsEntity> OrderItems { get; set; }
    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    

}
