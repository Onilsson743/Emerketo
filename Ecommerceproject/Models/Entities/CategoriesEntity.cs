namespace Ecommerceproject.Models.Entities
{
    public class CategoriesEntity
    {
        public int Id { get; set; }

        public string Category { get; set; } = null!;
        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();
    }
}
