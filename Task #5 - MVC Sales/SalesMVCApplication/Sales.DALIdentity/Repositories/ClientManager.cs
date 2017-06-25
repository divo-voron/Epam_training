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

        public void Update(ClientProfile item)
        {
            _database.ClientProfiles.Add(item);

            ClientProfile clientProfile = _database.ClientProfiles.FirstOrDefault(x => x.Id == item.Id);
            if (clientProfile != null)
            {
                clientProfile.Name = item.Name;
                clientProfile.Address = item.Address;

                _database.Entry<ClientProfile>(clientProfile).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
            }
        }
        public void Delete(ClientProfile item)
        {
            ClientProfile clientProfile = _database.ClientProfiles.FirstOrDefault(x => x.Id == item.Id);
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
