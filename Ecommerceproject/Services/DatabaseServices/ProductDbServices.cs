using Ecommerceproject.Context;
using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;
using Ecommerceproject.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
            ProductEntity productEntity = product;
                
            //    new ProductEntity()
            //{
            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    ProductDescription = product.ProductDescription,
            //    ProductInStock = product.ProductInStock
            //};       

            foreach (var category in product.ProductCategory)
            {
                var categoryEntity = await _db.Categories.SingleOrDefaultAsync(c => c.Category.ToLower() == category.Name.ToLower());
                if (categoryEntity == null)
                {
                    categoryEntity = new CategoriesEntity { Category = category.Name };
                    _db.Categories.Add(categoryEntity);
                    await _db.SaveChangesAsync();
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

            if (product.ProductImage != null)
            {
                foreach (var image in product.ProductImage)
                {
                    var productImageEntity = new ProductImageEntity
                    {
                        ImageUrl = $"{productEntity.ArticleNumber}_{image.FileName}",
                        ProductId = productEntity.ArticleNumber
                    };
                    _db.ProductImages.Add(productImageEntity);
                    await _db.SaveChangesAsync();
                    await _fileServices.SaveProductImageAsync(productImageEntity, image);
                    productEntity.ProductImageUrl!.Add(productImageEntity);
                }
            }
        }

        //Gets all products
        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            IEnumerable<ProductEntity> result = await _db.Products.
                Include(x => x.Categories).ThenInclude(c => c.Categories).
                Include(x => x.Colours).ThenInclude(c => c.Colour).
                Include(x => x.ProductImageUrl).
                ToListAsync();

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

                    var images = new List<string>();
                    foreach (var imageUrl in product.ProductImageUrl!)
                    {
                        images.Add(imageUrl.ImageUrl);
                    }
                                        

                    model.Add(new ProductModel
                    {
                        Id = product.ArticleNumber,
                        ProductName = product.ProductName,
                        Price = Math.Round(product.Price, 2),
                        ProductDescription = product.ProductDescription,
                        ProductInStock = product.ProductInStock,
                        ProductImageUrl = images,
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
            var result = await _db.Products.
                Include(x => x.Categories).ThenInclude(c => c.Categories).
                Include(x => x.Colours).ThenInclude(c => c.Colour).
                Include(x => x.ProductImageUrl).
                FirstOrDefaultAsync(x => x.ArticleNumber == articlenumber);
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

                var images = new List<string>();
                foreach (var imageUrl in result.ProductImageUrl!)
                {
                    images.Add(imageUrl.ImageUrl);
                }

                var product = new ProductModel
                {
                    Id = result.ArticleNumber,
                    ProductName = result.ProductName,
                    Price = Math.Round(result.Price, 2),
                    ProductDescription = result.ProductDescription,
                    ProductCategory = categories,
                    ProductInStock = result.ProductInStock,
                    ProductImageUrl = images,
                    Colours = colours

                };
                return product;
            }
            return null!;
        }
    }
}
