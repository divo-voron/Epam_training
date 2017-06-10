using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Components
{
    public class Manager
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Manager(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
