using Ecommerceproject.Context;
using Ecommerceproject.Services;
using Ecommerceproject.Services.DatabaseServices;
using Ecommerceproject.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddScoped<ProductDbRepo>();
builder.Services.AddScoped<ProductDbServices>();

builder.Services.AddScoped<ColourDbRepo>();
builder.Services.AddScoped<ColourDbServices>();

builder.Services.AddScoped<CategoryDbRepo>();
builder.Services.AddScoped<CategoryDbServices>();

builder.Services.AddScoped<ContactFormDbRepo>();
builder.Services.AddScoped<ContactFormDbServices>();



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
