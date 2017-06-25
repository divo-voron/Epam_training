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

        public IEnumerable<RolesDTO> GetRoles()
        {
            return Database.RoleManager.Roles.Select(x => new RolesDTO { ID = x.Id, Name = x.Name });
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                
                // добавляем роли
                foreach (var role in userDto.Roles)
                {
                    await Database.UserManager.AddToRoleAsync(user.Id, role);
                }

                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }
        public async Task<OperationDetails> Update(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByIdAsync(userDto.Id);
            if (user != null)
            {
                user = new ApplicationUser
                {
                    Id = userDto.Id,
                    Email = userDto.Email,
                    UserName = userDto.Email,
                };

                var result = await Database.UserManager.UpdateAsync(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                foreach (var role in Database.RoleManager.Roles.Select(x => x.Id))
                {
                    Database.UserManager.RemoveFromRole(user.Id, role);
                }

                // добавляем роли
                foreach (var role in userDto.Roles)
                {
                    await Database.UserManager.AddToRoleAsync(user.Id, role);
                }

                // обновляем профиль клиента

                user.ClientProfile = new ClientProfile() 
                {
                    Id = user.Id,
                    Address = userDto.Address,
                    Name = userDto.Name
                };

                //ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };

                //Database.ClientManager.Create(clientProfile);
                
                await Database.SaveAsync();
                
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь не существует", "Email");
            }
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
