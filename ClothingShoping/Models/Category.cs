using System.ComponentModel.DataAnnotations;

namespace ClothingShoping.Models
{
    public class Category : BaseEntity
    {
        [StringLength(40)]
        public string Image { get; set; }
        public virtual List<Product> Products { get; set; }

        public virtual List<Size> Sizes { get; set; }
    }
}
