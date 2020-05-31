using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Maps;
using ProductCatalog.Entities;

namespace ProductCatalog.Data
{
    public class StoreContextDb : DbContext
    {
        public StoreContextDb(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=mystore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
