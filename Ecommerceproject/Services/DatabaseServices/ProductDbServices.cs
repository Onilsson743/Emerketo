using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices
{
    public class ProductDbServices
    {
        private readonly ProductDbRepo _productManager;

        public ProductDbServices(ProductDbRepo productManager)
        {
        
            _productManager = productManager;
        }

        public async Task AddAsync(ProductViewModel product)
        {
            ProductEntity product = form;
            product.CategoryId = (await _categoryManager.GetOrCreateAsync(form.Category)).Id;

            await _productManager.AddAsync(product);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _productManager.GetAllAsync();
        }
    }
}
