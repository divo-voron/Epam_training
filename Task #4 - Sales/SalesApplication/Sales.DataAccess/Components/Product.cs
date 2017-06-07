using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Components
{
    class Product
    {
        private int _id;
        public string Name { get; set; }

        public Product(int id, string name)
        {
            _id = id;
            Name = name;
        }
    }
}
