﻿using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class ProductCategoryRepo : MainRepo<CategoriesEntity>
    {
        public ProductCategoryRepo(DataContext db) : base(db)
        { 
        }
    }
}
