using DTO;
using System.Collections.Generic;

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
