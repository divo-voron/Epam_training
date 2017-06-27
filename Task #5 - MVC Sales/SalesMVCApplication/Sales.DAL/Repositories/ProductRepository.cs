using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class ProductRepository : IRepository<Product>
    {
        private Sales.Model.Models.SalesDataBaseContext _context;

        public ProductRepository(Sales.Model.Models.SalesDataBaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product item)
        {
            Sales.Model.Models.Product product = _context.Products.Find(item.ID);
            if (product == null)
                _context.Products.Add(item);
        }

        public void Update(Product item)
        {
            Sales.Model.Models.Product product = _context.Products.Find(item.ID);
            if (product != null)
            {
                product.Name = item.Name;
                _context.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Sales.Model.Models.Product product = _context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
        }
    }
}
