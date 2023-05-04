using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class UserDbRepo : MainRepo<UserEntity>
    {
        public UserDbRepo(DataContext db) : base(db)
        {
        }
    }
}
