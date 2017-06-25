using Microsoft.AspNet.Identity;
using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using Sales.BLIdentity.Interfaces;
using Sales.DALIdentity.Entities;
using Sales.DALIdentity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLIdentity.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<UserDTO> GetUsers()
        {
            ICollection<UserDTO> usersDTO = new List<UserDTO>();

            foreach (var user in Database.UserManager.Users)
            {
                // TODO: Сделать как-нибудь получше (:

                IEnumerable<string> userRolesId = user.Roles.Select(x => x.RoleId);

                usersDTO.Add(new UserDTO()
                {
                    Id = user.Id,
                    Name = user.ClientProfile.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    Address = user.ClientProfile.Address,
                    Roles = Database.RoleManager.Roles.Where(x => userRolesId.Contains(x.Id)).Select(x => x.Name)
                });
            }

            return usersDTO;
        }

        public IEnumerable<string> GetRoles()
        {
            return Database.RoleManager.Roles.Select(x => x.Name);
        }

        public OperationDetails Create(UserDTO userDto)
        {
            ApplicationUser user = Database.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = Database.UserManager.Create(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                
                // добавляем роли
                foreach (var role in userDto.Roles)
                {
                    Database.UserManager.AddToRole(user.Id, role);
                }

                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }
        public OperationDetails Update(UserDTO userDto)
        {
            ApplicationUser user = Database.UserManager.FindById(userDto.Id);
            if (user != null)
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                user.Roles.Clear();
                user.ClientProfile.Address = userDto.Address;
                user.ClientProfile.Name = userDto.Name;

                var result = Database.UserManager.Update(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем новые роли
                foreach (var role in userDto.Roles)
                {
                    Database.UserManager.AddToRole(user.Id, role);
                }

                Database.SaveAsync();
                
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь не существует", "Email");
            }
        }
        public OperationDetails Delete(UserDTO userDto)
        {
            ApplicationUser user = Database.UserManager.FindById(userDto.Id);
            if (user != null)
            {
                Database.ClientManager.Delete(user.ClientProfile);
                var result = Database.UserManager.Delete(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                Database.SaveAsync();

                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь не существует", "Email");
            }
        }
        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = Database.UserManager.Find(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = Database.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public void SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = Database.RoleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    Database.RoleManager.Create(role);
                }
            }
            Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
