using Sales.DALIdentity.EF;
using Sales.DALIdentity.Entities;
using Sales.DALIdentity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DALIdentity.Repositories
{
    public class ClientManager : IClientManager
    {
        private ApplicationContext _database;
        public ClientManager(ApplicationContext db)
        {
            _database = db;
        }

        public void Create(ClientProfile item)
        {
            _database.ClientProfiles.Add(item);
            _database.SaveChanges();
        }

        public void Delete(ClientProfile item)
        {
            ClientProfile clientProfile = _database.ClientProfiles.Find(item.Id);
            if (clientProfile != null)
            {
                _database.ClientProfiles.Remove(clientProfile);
                _database.SaveChanges();
            }
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
