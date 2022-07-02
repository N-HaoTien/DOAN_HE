using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ClothingShoping.Models
{
    public class Product : BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }

        public virtual Category Category { get; set; }
        [Required]

        public int CategoryId { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

        public virtual List<ProductPicture> ProductPictures { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<ProductSize> ProductSizes { get; set; }


    }
}
