using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rheem.Inventory.Api.Models
{
    public class InventoryItem
    {
        [Key] // Explicitly marking this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; } = 0.00m;

        [StringLength(50)]
        public string ProductCategory { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
