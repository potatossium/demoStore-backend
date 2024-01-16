using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStoreWeek7.Models
{
    public class Customer
    {
        [Key]  // use DataAnnotations to set the primary key
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column("Address", TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Address { get; set; }

        // define the navigation Properties
        public virtual ICollection<Sale> ProductSold { get; set; }
    }

    public class CreateCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class UpdateCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
