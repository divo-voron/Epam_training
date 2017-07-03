using Sales.BL.DTO;
using Sales.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Services
{
    public class ProductCRUD : IProductCRUD
    {
        Sales.DAL.Interfaces.ISalesUnitOfWork unit;
        BLMapper Mapper;

        public ProductCRUD(Sales.DAL.Interfaces.ISalesUnitOfWork uow)
        {
            unit = uow;
            Mapper = new BLMapper();
        }
        public IEnumerable<ProductDto> Products
        {
            get { return unit.Products.GetAll().Select(x => Mapper.Mapping(x)); }
        }
        public IEnumerable<ProductDto> GetProductPerPage(int pageSize, int pageNumber)
        {
            if (unit.Products.Count() >= (pageNumber - 1) * pageSize)
                return unit.Products.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(x => Mapper.Mapping(x));
            else
                throw new IndexOutOfRangeException("End of Products");
        }
        public void AddProduct(ProductDto product)
        {
            unit.Products.Create(Mapper.Mapping(product));
            unit.Save();
        }
        public void EditProduct(ProductDto product)
        {
            unit.Products.Update(Mapper.Mapping(product));
            unit.Save();
        }
        public void DeleteProduct(int id)
        {
            unit.Products.Delete(id);
            unit.Save();
        }
    }
}
