using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUserProvider : IProvider<UsersDto>
    {
        bool IsInRole(string role, int id);
        UsersDto GetByInfo(UsersDto user);
        IEnumerable<UsersDto> GetAll(int skip, int amount);
        void ChangeRole(int userId, int roleId);
        int GetAmountUsers();
        void SaveChanges();
    }
}
