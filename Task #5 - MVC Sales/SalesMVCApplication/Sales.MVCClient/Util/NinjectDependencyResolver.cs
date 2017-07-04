using Ninject;
using Sales.BL.Interfaces;
using Sales.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sales.MVCClient.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IClientCRUD>().To<ClientCRUD>();
            kernel.Bind<IManagerCRUD>().To<ManagerCRUD>();
            kernel.Bind<IOperationCRUD>().To<OperationCRUD>();
            kernel.Bind<IPriceHistoryCRUD>().To<PriceHistoryCRUD>();
            kernel.Bind<IProductCRUD>().To<ProductCRUD>();
        }
    }
}