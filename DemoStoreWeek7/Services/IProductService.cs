using DemoStoreWeek7.Models;

namespace DemoStoreWeek7.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(int? id);
        Task<int> CreateProduct(CreateProduct model);
        Task<Product> UpdateProduct(UpdateProduct model);
        Task DeleteProduct(int Id);
    }
}
