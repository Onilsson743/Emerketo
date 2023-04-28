using Ecommerceproject.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Ecommerceproject.Context;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<CategoriesEntity> Categories { get; set; }
    public DbSet<ColourEntity> Colours { get; set; }
    public DbSet<ContactformEntity> ContactForms { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemsEntity> OrderItems { get; set; }
    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ProductColoursEntity> ProductColours { get; set; }
    public DbSet<ProductEntity> Products { get; set; }    
    public DbSet<UserEntity> Users { get; set; }
}
