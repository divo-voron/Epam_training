using Sales.DAL.Interfaces;
using Sales.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Sales.BL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<ISalesUnitOfWork>().To<SalesUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
