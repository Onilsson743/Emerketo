using Ecommerceproject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Ecommerceproject.Context;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Adresses { get; set; }
    public DbSet<CategoriesEntity> Categories { get; set; }
    public DbSet<ColourEntity> Colours { get; set; }
    public DbSet<ContactformEntity> ContactForms { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemsEntity> OrderItems { get; set; }
    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ProductColoursEntity> ProductColours { get; set; }
    public DbSet<ProductEntity> Products { get; set; }    
    public DbSet<UserAddressEntity> UserAdresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN",
        },
        new IdentityRole
        {
            Name = "Manager",
            NormalizedName = "MANAGER"
        },
        new IdentityRole
        {
            Name = "Member",
            NormalizedName = "MEMBER"
        });
        // var passwordHasher = new PasswordHasher<UserEntity>();
        //builder.Entity<UserEntity>().HasData(new UserEntity
        //{
        //    FirstName = "System",
        //    LastName = "Administrator",
        //    UserName = "administrator",
        //    PasswordHash = passwordHasher.HashPassword(null!, "BytMig123!"),

        //});
    }
}
