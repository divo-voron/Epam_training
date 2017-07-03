using Sales.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Interfaces
{
    public interface IProductCRUD
    {
        IEnumerable<ProductDto> Products{get;}
        IEnumerable<ProductDto> GetProductPerPage(int pageSize, int pageNumber);
        void AddProduct(ProductDto product);
        void EditProduct(ProductDto product);
        void DeleteProduct(int id);
    }
}
