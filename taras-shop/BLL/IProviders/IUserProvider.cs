using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUserProvider : IProvider<UsersDto>
    {
        Task<ClaimsIdentity> Authenticate(UsersDto user);
        Task SetInitialData(UsersDto user, List<string> roles);
        UsersDto GetByInfo(UsersDto user);
    }
}
