using DemoStoreWeek7.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Services
{
    public class ProductService: IProductService
    {
        private readonly DemoStoreDBContext _context;
        public ProductService(DemoStoreDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            // ToListAsync() method is from EntityFrameworkCore
            var products = await _context.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetProduct(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        public async Task<int> CreateProduct(CreateProduct model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<Product> UpdateProduct(UpdateProduct model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price
            };
            var existingProduct = await _context.Products.FindAsync(model.Id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = new Product { Id = id };
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
