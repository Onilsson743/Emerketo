using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class CategoryDbRepo : MainRepo<CategoriesEntity>
    {
        public CategoryDbRepo(DataContext db) : base(db)
        {
        }
    }
}
