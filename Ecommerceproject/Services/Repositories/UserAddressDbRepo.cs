using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class UserAddressDbRepo : MainRepo<UserAddressEntity>
    {
        public UserAddressDbRepo(DataContext db) : base(db)
        {
        }
    }
}
