using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Sales.DALIdentity.Entities;

namespace Sales.DALIdentity.Identity
{
    // класс для добавления и аутентификации пользователей в базе
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}
