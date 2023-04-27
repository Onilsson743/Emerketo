using Ecommerceproject.Context;
using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Ecommerceproject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerceproject.Services.DatabaseServices
{
    public class ProductDbServices
    {
        private readonly ProductDbRepo _productService;
        private readonly DataContext _db;


        public ProductDbServices(ProductDbRepo productService, DataContext db)
        {
            _productService = productService;
            _db = db;
        }



        //Adds Product to db
        public async Task AddAsync(AddProductViewModel product)
        {
            ProductEntity productEntity = new ProductEntity()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ProductInStock = product.ProductInStock,
                ProductImageUrl = product.ProductImageUrl,
            };


            foreach (string category in product.ProductCategory)
            {
                var categoryEntity = await _db.Categories.SingleOrDefaultAsync(c => c.Category == category);
                if (categoryEntity == null)
                {
                    categoryEntity = new CategoriesEntity { Category = category };
                    _db.Categories.Add(categoryEntity);
                }

                var productCategoryEntity = new ProductCategoryEntity
                {
                    Product = productEntity,
                    Categories = categoryEntity
                };

                productEntity.Categories.Add(productCategoryEntity);
            }
            foreach (var colour in product.ColoursList)
            {
                if (colour.IsChecked == true)
                {
                    var colourEntity = await _db.Colours.SingleOrDefaultAsync(c => c.Colour.ToLower() == colour.Name.ToLower());
                    if (colourEntity == null)
                    {
                        colourEntity = new ColourEntity { Colour = colour.Name };
                        _db.Colours.Add(colourEntity);
                    }

                    var productColourEntity = new ProductColoursEntity
                    {
                        Product = productEntity,
                        Colour = colourEntity
                    };

                    productEntity.Colours.Add(productColourEntity);
                }
            }

            await _productService.AddAsync(productEntity);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            IEnumerable<ProductEntity> result = await _db.Products.Include(x => x.Categories).ThenInclude(c => c.Categories).Include(x => x.Colours).ThenInclude(c => c.Colour).ToListAsync();
            if (result != null)
            {
                ProductModel model = new ProductModel();
                foreach (var product in result)
                {
                    model.Id = product.Id;
                    model.ProductName = product.ProductName;
                    model.Price = product.Price;
                    model.ProductDescription = product.ProductDescription;
                    model.ProductInStock = product.ProductInStock;
                    model.ProductImageUrl = product.ProductImageUrl;

                    var categories = new List<string>();
                    foreach (var category in product.Categories)
                    {
                        categories.Add(category.Categories.Category);
                    }
                    model.ProductCategory = categories;

                    var colours = new List<string>();
                    foreach (var colour in product.Colours)
                    {
                        colours.Add(colour.Colour.Colour);
                    }
                    model.Colours = colours;

                }
                return (IEnumerable<ProductModel>)model;
            }
            return null!;
        }
    }
}
