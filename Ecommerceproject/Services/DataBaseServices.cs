using Ecommerceproject.Context;
using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Ecommerceproject.Services;

public class DataBaseServices
{
    private readonly DataContext db;

    public DataBaseServices(DataContext Database)
    {
        db = Database;
    }

    //public async Task<IEnumerable<ProductModel>> GetAllProducts()
    //{
        //IEnumerable<ProductEntity> result = await db.Products.Include(c => c.Colours).ToListAsync();
        //List<ProductModel> productList = new List<ProductModel>();
        //foreach (var item in result)
        //{
        //    var product = new ProductModel()
        //    {
        //        Id = item.Id,
        //        ProductName = item.ProductName,
        //        Price = item.Price,
        //        ProductDescription = item.ProductDescription,
        //        ProductCategory = item.ProductCategory,
        //        ProductInStock = item.ProductInStock,
        //        ProductImageUrl = item.ProductImageUrl                
        //    };
        //    foreach (var x in item.Colours)
        //    {
        //        //product.Colours.Add(x.Colour);
        //    }

        //    productList.Add(product);
        //} 

        //return productList;
    //}
}
