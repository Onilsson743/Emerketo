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
        #region
        private readonly ProductDbRepo _productService;
        private readonly DataContext _db;
        private readonly FileUploadServices _fileServices;
        public ProductDbServices(ProductDbRepo productService, DataContext db, FileUploadServices fileServices)
        {
            _productService = productService;
            _db = db;
            _fileServices = fileServices;
        }
        #endregion



        //Adds Product to db
        public async Task AddAsync(AddProductViewModel product)
        {
            ProductEntity productEntity = new ProductEntity()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ProductInStock = product.ProductInStock
            };
            if (product.ProductImage != null)
            {
                productEntity.ProductImageUrl = $"{productEntity.ArticleNumber}_{product.ProductImage.FileName}";
                await _fileServices.SaveProductImageAsync(productEntity, product.ProductImage);
            }
            


            foreach (var category in product.ProductCategory)
            {
                var categoryEntity = await _db.Categories.SingleOrDefaultAsync(c => c.Category.ToLower() == category.Name.ToLower());
                if (categoryEntity == null)
                {
                    categoryEntity = new CategoriesEntity { Category = category.Name };
                    _db.Categories.Add(categoryEntity);
                    _db.SaveChanges();
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
                        _db.SaveChanges();
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

        //Gets all products
        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            IEnumerable<ProductEntity> result = await _db.Products.Include(x => x.Categories).ThenInclude(c => c.Categories).Include(x => x.Colours).ThenInclude(c => c.Colour).ToListAsync();
            if (result != null)
            {
                List<ProductModel> model = new List<ProductModel>();

                foreach (var product in result)
                {
                    var categories = new List<string>();
                    foreach (var category in product.Categories)
                    {
                        categories.Add(category.Categories.Category);
                    }

                    var colours = new List<string>();
                    foreach (var colour in product.Colours)
                    {
                        colours.Add(colour.Colour.Colour);
                    }
                    model.Add(new ProductModel
                    {
                        Id = product.ArticleNumber,
                        ProductName = product.ProductName,
                        Price = Math.Round(product.Price, 2),
                        ProductDescription = product.ProductDescription,
                        ProductInStock = product.ProductInStock,
                        ProductImageUrl = product.ProductImageUrl!,
                        ProductCategory = categories,
                        Colours = colours                        
                    });
                }

                return model;
            }
            return null!;
        }

        //Gets one product
        public async Task<ProductModel> GetOneAsync(Guid articlenumber)
        {
            var result = await _db.Products.Include(x => x.Categories).ThenInclude(c => c.Categories).Include(x => x.Colours).ThenInclude(c => c.Colour).FirstOrDefaultAsync(x => x.ArticleNumber == articlenumber);
            if (result != null)
            {
                var categories = new List<string>();
                foreach (var category in result.Categories)
                {
                    categories.Add(category.Categories.Category);
                }

                var colours = new List<string>();
                foreach (var colour in result.Colours)
                {
                    colours.Add(colour.Colour.Colour);
                }
                var product = new ProductModel
                {
                    Id = result.ArticleNumber,
                    ProductName = result.ProductName,
                    Price = Math.Round(result.Price, 2),
                    ProductDescription = result.ProductDescription,
                    ProductCategory = categories,
                    ProductInStock = result.ProductInStock,
                    ProductImageUrl = result.ProductImageUrl!,
                    Colours = colours

                };
                return product;
            }
            return null!;
        }
    }
}
