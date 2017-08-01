using Sales.DAL.Interfaces;
using Sales.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    class ManagerRepository : AbstractRepository<Manager>
    {
        public ManagerRepository(Sales.Model.Models.SalesDataBaseContext context):
            base(context)
        {
        }
    }
}
