using DemoStoreWeek7.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Services
{
    public class SaleService: ISaleService
    {
        private readonly DemoStoreDBContext _context;
        public SaleService(DemoStoreDBContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetSales()
        {
            // ToListAsync() method is from EntityFrameworkCore
            var sales = await _context.Sales.ToListAsync();
            return sales;
        }
        public async Task<Sale> GetSale(int? id)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(x => x.Id == id);
            return sale;
        }
        public async Task<int> CreateSale(CreateSale model)
        {
            var sale = new Sale
            {
                CustomerId = model.CustomerId,
                ProductId = model.ProductId,
                StoreId = model.StoreId,
                DateSold = model.DateSold,
            };

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return sale.Id;
        }

        public async Task<Sale> UpdateSale(UpdateSale model)
        {
            var sale = new Sale
            {
                CustomerId = model.CustomerId,
                ProductId = model.ProductId,
                StoreId = model.StoreId,
                DateSold = model.DateSold,
            };
            var existingSale = await _context.Sales.FindAsync(model.Id);
            if (existingSale == null)
            {
                return null;
            }
            existingSale.CustomerId = model.CustomerId;
            existingSale.ProductId = model.ProductId;
            existingSale.StoreId = model.StoreId;
            existingSale.ProductId = model.ProductId;

            _context.Sales.Update(existingSale);
            await _context.SaveChangesAsync();

            return existingSale;
        }

        public async Task DeleteSale(int id)
        {
            var sale = new Sale { Id = id };
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }

    }
}
