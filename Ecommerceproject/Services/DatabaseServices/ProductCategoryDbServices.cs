﻿using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices
{
    public class ProductCategoryDbServices
    {
        private readonly ProductCategoryRepo _categoryRepo;

        public ProductCategoryDbServices(ProductCategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ProductCategoryEntity> GetOrCreateAsync(string category)
        {
            var categoryEntity = await _categoryRepo.GetAsync(x => x.Category == category);
            if(categoryEntity == null)
            {
                CategoriesEntity newCategoryEntity = new CategoriesEntity();
                newCategoryEntity.Category = category;
                await _categoryRepo.AddAsync(newCategoryEntity);

            }
            //categoryEntity ??= await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = model.Name });
            return null!;
        }

        //public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesAsync()
        //{
        //    var items = await _categoryRepo.GetAllAsync();
        //    var categories = new List<ProductCategoryModel>();

        //    foreach (var item in items)
        //        categories.Add(new ProductCategoryModel { Name = item.CategoryName, Value = item.Id });

        //    return categories;
        //}
    }
}
