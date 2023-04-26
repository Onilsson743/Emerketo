using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class ProductDbRepo : MainRepo<ProductEntity>
    {
        public ProductDbRepo(DataContext db) : base(db)
        {
        }
    }
}
