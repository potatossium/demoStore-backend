using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoStoreWeek7.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        // define the navigation properties
        public virtual ICollection<Sale> ProductSold { get; set; }
    }

    public class CreateProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
