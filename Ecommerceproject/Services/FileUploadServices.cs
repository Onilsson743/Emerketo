using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;

namespace Ecommerceproject.Services;

public class FileUploadServices
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploadServices(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> SaveProductImageAsync(ProductImageEntity productImage, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/Images/ProductImages/{productImage.ImageUrl}";
            using var stream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(stream);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> SaveProfileImageAsync(UserEntity user, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/Images/ProfileImages/{user.ImageUrl}";
            using var stream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(stream);
            return true;
        }
        catch { return false; }
    }
}
