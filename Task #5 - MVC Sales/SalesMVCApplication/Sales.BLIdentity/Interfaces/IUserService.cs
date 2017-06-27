using Sales.BLIdentity.DTO;
using Sales.BLIdentity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLIdentity.Interfaces
{
    public interface IUserService : IDisposable
    {
        OperationDetails Create(UserDto userDto);
        OperationDetails Update(UserDto userDto);
        OperationDetails Delete(UserDto userDto);
        ClaimsIdentity Authenticate(UserDto userDto);
        void SetInitialData(UserDto adminDto, List<string> roles);

        ICollection<UserDto> GetUsers();
        IEnumerable<string> GetRoles();
    }
}
