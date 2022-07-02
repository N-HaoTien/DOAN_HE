using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClothingShoping.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}
