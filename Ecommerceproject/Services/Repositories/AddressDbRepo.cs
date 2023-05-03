using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class AddressDbRepo : MainRepo<AddressEntity>
    {
        public AddressDbRepo(DataContext db) : base(db)
        {
        }
    }
}
