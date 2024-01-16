using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Models
{
    public partial class DemoStoreDBContext:DbContext
    {
        public DemoStoreDBContext(DbContextOptions<DemoStoreDBContext> options)
            :base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.ProductSold)
                .WithOne(s => s.Customer);
            modelBuilder.Entity<Store>()
                .HasMany(st => st.ProductSold)
                .WithOne(s => s.Store);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductSold)
                .WithOne(s => s.Product);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
