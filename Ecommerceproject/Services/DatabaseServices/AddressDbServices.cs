using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices;

public class AddressDbServices
{
    #region
    private readonly AddressDbRepo _addressRepo;
    private readonly UserAddressDbRepo _userAddressRepo;

    public AddressDbServices(AddressDbRepo addressRepo, UserAddressDbRepo userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userAddressRepo = userAddressRepo;
    }
    #endregion


    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity address)
    {
        var entity = await _addressRepo.GetAsync(x => x.StreetName == address.StreetName && x.City == address.City && x.PostalCode == address.PostalCode);

        entity ??= await _addressRepo.AddAsync(address);
        return entity;
    }

    public async Task AddAddressAsync(UserEntity user, AddressEntity address)
    {
        UserAddressEntity useradress = new UserAddressEntity
        {
            UserId = user.Id,
            AddressId = address.Id,
        };
        await _userAddressRepo.AddAsync(useradress);
        //await _userAddressRepo.AddAsync(new UserAddressEntity
        //{
        //    UserId = user.Id,
        //    AddressId = address.Id,
        //});
    }
}
