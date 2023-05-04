using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices;

public class UserDbServices
{
    private readonly UserDbRepo _userRepo;

    public UserDbServices(UserDbRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<bool> CheckAnyUserAsync()
    {
        var result = await _userRepo.GetAllAsync();
        if (result.Any())
        {
            return true;
        }
        return false;
    }
}
