using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class CategoryRepo : MainRepo<CategoriesEntity>
    {
        public CategoryRepo(DataContext db) : base(db)
        {
        }
    }
}
