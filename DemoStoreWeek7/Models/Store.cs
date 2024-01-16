using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoStoreWeek7.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column("Address", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Address { get; set; }

        // define the navigation properties
        public virtual ICollection<Sale> ProductSold { get; set; }
    }

    public class CreateStore
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class UpdateStore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
