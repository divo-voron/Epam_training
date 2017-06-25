using Sales.DALIdentity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DALIdentity.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        void Update(ClientProfile item);
        void Delete(ClientProfile item);
    }
}
