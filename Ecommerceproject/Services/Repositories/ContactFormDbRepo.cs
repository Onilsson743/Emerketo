using Ecommerceproject.Context;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services.Repositories
{
    public class ContactFormDbRepo : MainRepo<ContactformEntity>
    {
        public ContactFormDbRepo(DataContext db) : base(db)
        {
        }
    }
}
