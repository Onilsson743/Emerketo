using Ecommerceproject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Ecommerceproject.Services.Claims
{


    // REMOVE THIS
    public class CustomClaims : UserClaimsPrincipalFactory<UserEntity>
    {
        private readonly UserManager<UserEntity> _userManager;

        public CustomClaims(UserManager<UserEntity> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));

            return claimsIdentity;
        }
    }
}
