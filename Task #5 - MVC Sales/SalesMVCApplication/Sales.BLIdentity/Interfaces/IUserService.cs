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
        OperationDetails Create(UserDTO userDto);
        OperationDetails Update(UserDTO userDto);
        OperationDetails Delete(UserDTO userDto);
        ClaimsIdentity Authenticate(UserDTO userDto);
        void SetInitialData(UserDTO adminDto, List<string> roles);

        ICollection<UserDTO> GetUsers();
        IEnumerable<string> GetRoles();
    }
}
