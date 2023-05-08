using Ecommerceproject.Models;
using Ecommerceproject.Models.Entities;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices
{
    public class CategoryDbServices
    {
        #region
        private readonly CategoryDbRepo _categoryService;

        public CategoryDbServices(CategoryDbRepo categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion


        //Gets all available categories
        public async Task<List<CheckBoxModel>> GetAllCategories()
        {
            var result = await _categoryService.GetAllAsync();
            if (result != null)
            {
                List<CheckBoxModel> categories = new List<CheckBoxModel>();
                foreach (var category in result)
                {
                    categories.Add(new CheckBoxModel
                    {
                        Name = category.Category
                    });
                }
                return categories;
            }
            return null!;
        }

    }
}
