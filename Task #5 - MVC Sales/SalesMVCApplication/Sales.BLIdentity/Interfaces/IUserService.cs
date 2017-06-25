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
        Task<OperationDetails> Create(UserDTO userDto);
        Task<OperationDetails> Update(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);

        ICollection<UserDTO> GetUsers();
        IEnumerable<RolesDTO> GetRoles();
    }
}
