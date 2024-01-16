using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoStoreWeek7.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }

        // define the navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }

    public class CreateSale
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }
    }

    public class UpdateSale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }
    }

    public class SaleDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }
        // define the properties for the related entities
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }
    }

}
