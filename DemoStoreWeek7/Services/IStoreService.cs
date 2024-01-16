using DemoStoreWeek7.Models;

namespace DemoStoreWeek7.Services
{
    public interface IStoreService
    {
        Task<List<Store>> GetStores();

        Task<Store> GetStore(int? id);
        Task<int> CreateStore(CreateStore model);
        Task<Store> UpdateStore(UpdateStore model);
        Task DeleteStore(int Id);
    }
}
