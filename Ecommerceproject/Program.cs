using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.Services.DatabaseServices.AuthenticationServices;
using Ecommerceproject.Services.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x =>
    {
        x.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
    }
);


//Repos
builder.Services.AddScoped<ProductDbRepo>();
builder.Services.AddScoped<ColourDbRepo>();
builder.Services.AddScoped<CategoryDbRepo>();
builder.Services.AddScoped<ContactFormDbRepo>();
builder.Services.AddScoped<UserDbRepo>();
builder.Services.AddScoped<AddressDbRepo>();
builder.Services.AddScoped<UserAddressDbRepo>();

//Services
builder.Services.AddScoped<ProductDbServices>();
builder.Services.AddScoped<ColourDbServices>();
builder.Services.AddScoped<CategoryDbServices>();
builder.Services.AddScoped<ContactFormDbServices>();
builder.Services.AddScoped<UserDbServices>();
builder.Services.AddScoped<AddressDbServices>();
builder.Services.AddScoped<FileUploadServices>();
builder.Services.AddScoped<AuthenticationDbService>();


//Identity
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>().AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/SignIn";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";    
});




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
