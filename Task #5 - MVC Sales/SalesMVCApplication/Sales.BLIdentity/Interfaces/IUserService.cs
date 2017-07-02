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
        Task<OperationDetails> Create(UserDto userDto);
        Task<OperationDetails> Update(UserDto userDto);
        Task<OperationDetails> Delete(string id);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task SetInitialData(UserDto adminDto, List<string> roles);

        ICollection<UserDto> GetUsers();
        IEnumerable<string> GetRoles();
    }
}
