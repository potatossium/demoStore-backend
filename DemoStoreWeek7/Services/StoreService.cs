using DemoStoreWeek7.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Services
{
    public class StoreService: IStoreService
    {
        private readonly DemoStoreDBContext _context;
        public StoreService(DemoStoreDBContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> GetStores()
        {
            // ToListAsync() method is from EntityFrameworkCore
            var stores = await _context.Stores.ToListAsync();
            return stores;
        }
        public async Task<Store> GetStore(int? id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            return store;
        }
        public async Task<int> CreateStore(CreateStore model)
        {
            var store = new Store
            {
                Name = model.Name,
                Address = model.Address
            };

            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return store.Id;
        }

        public async Task<Store> UpdateStore(UpdateStore model)
        {
            var store = new Store
            {
                Name = model.Name,
                Address = model.Address
            };
            var existingStore = await _context.Stores.FindAsync(model.Id);
            if (existingStore == null)
            {
                return null;
            }
            existingStore.Name = model.Name;
            existingStore.Address = model.Address;

            _context.Stores.Update(existingStore);
            await _context.SaveChangesAsync();

            return store;
        }

        public async Task DeleteStore(int id)
        {
            var store = new Store { Id = id };
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }

    }
}
