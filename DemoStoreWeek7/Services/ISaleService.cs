using DemoStoreWeek7.Models;

namespace DemoStoreWeek7.Services
{
    public interface ISaleService
    {
        Task<List<Sale>> GetSales();

        Task<Sale> GetSale(int? id);
        Task<int> CreateSale(CreateSale model);
        Task<Sale> UpdateSale(UpdateSale model);
        Task DeleteSale(int Id);
    }
}
