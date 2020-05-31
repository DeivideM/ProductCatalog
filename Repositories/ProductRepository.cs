using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Entities;
using ProductCatalog.ViewModels.ProductViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Repositories
{
    public class ProductRepository
    {
        private readonly StoreContextDb _context;
        public ProductRepository(StoreContextDb context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                     .Include(x => x.Category)
                     .Select(x => new ListProductViewModel
                     {
                         ProductId = x.ProductId,
                         ProductName = x.ProductName,
                         Price = x.Price,
                         Category = x.Category.CategoryName,
                         CategoryId = x.Category.CategoryId
                     })
                     .AsNoTracking()
                     .ToList();
        }

        public Product Get(int id)
        {
            //return _context.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return _context.Products.Find(id);
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
