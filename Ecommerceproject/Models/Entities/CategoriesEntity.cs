using Ecommerceproject.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommerceproject.Models;

namespace Ecommerceproject.Models.Entities
{
    public class CategoriesEntity
    {
        [Key]
        public int Id { get; set; }

        public string Category { get; set; } = null!;
        public List<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();
    }
}

