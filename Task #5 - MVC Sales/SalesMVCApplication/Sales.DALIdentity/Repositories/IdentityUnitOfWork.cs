using Microsoft.AspNet.Identity.EntityFramework;
using Sales.DALIdentity.EF;
using Sales.DALIdentity.Entities;
using Sales.DALIdentity.Identity;
using Sales.DALIdentity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DALIdentity.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private ApplicationContext _db;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IClientManager _clientManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }
        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }
        public IClientManager ClientManager
        {
            get { return _clientManager; }
        }

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
