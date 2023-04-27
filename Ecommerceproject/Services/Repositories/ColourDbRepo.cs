using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class ColourDbRepo : MainRepo<ColourEntity>
    {
        public ColourDbRepo(DataContext db) : base(db)
        {
        }
    }
}
