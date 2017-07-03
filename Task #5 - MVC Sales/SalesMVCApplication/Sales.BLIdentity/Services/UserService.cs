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
    class UserService : IUserService
    {
        IIdentityUnitOfWork unit;

        public UserService(IIdentityUnitOfWork uow)
        {
            unit = uow;
        }

        public ICollection<UserDto> GetUsers()
        {
            ICollection<UserDto> usersDTO = new List<UserDto>();

            foreach (var user in unit.UserManager.Users)
            {
                // TODO: Сделать как-нибудь получше (:

                IEnumerable<string> userRolesId = user.Roles.Select(x => x.RoleId);

                usersDTO.Add(new UserDto()
                {
                    Id = user.Id,
                    Name = user.ClientProfile.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    Address = user.ClientProfile.Address,
                    Roles = unit.RoleManager.Roles.Where(x => userRolesId.Contains(x.Id)).Select(x => x.Name)
                });
            }

            return usersDTO;
        }

        public IEnumerable<string> GetRoles()
        {
            return unit.RoleManager.Roles.Select(x => x.Name);
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            ApplicationUser user = await unit.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await unit.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем роли
                await unit.UserManager.AddToRolesAsync(user.Id, userDto.Roles.ToArray());
                
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                unit.ClientManager.Create(clientProfile);
                await unit.SaveAsync();
                return new OperationDetails(true, "Registration successful", "");
            }
            else
            {
                return new OperationDetails(false, "User with such login already exists", "Email");
            }
        }
        public async Task<OperationDetails> Update(UserDto userDto)
        {
            ApplicationUser user = await unit.UserManager.FindByIdAsync(userDto.Id);
            if (user != null)
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                user.Roles.Clear();
                user.ClientProfile.Address = userDto.Address;
                user.ClientProfile.Name = userDto.Name;

                var result = await unit.UserManager.UpdateAsync(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // добавляем новые роли
                await unit.UserManager.AddToRolesAsync(user.Id, userDto.Roles.ToArray());
                
                await unit.SaveAsync();

                return new OperationDetails(true, "Registration successful", "");
            }
            else
            {
                return new OperationDetails(false, "User does not exist", "Email");
            }
        }
        public async Task<OperationDetails> Delete(string id)
        {
            ApplicationUser user = await unit.UserManager.FindByIdAsync(id);
            if (user != null)
            {
                unit.ClientManager.Delete(user.ClientProfile);
                var result = unit.UserManager.Delete(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                await unit.SaveAsync();

                return new OperationDetails(true, "Registration successful", "");
            }
            else
            {
                return new OperationDetails(false, "User does not exist", "Email");
            }
        }
        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await unit.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await unit.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await unit.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await unit.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            unit.Dispose();
        }
    }
}
