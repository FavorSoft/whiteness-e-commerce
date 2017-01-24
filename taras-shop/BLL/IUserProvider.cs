using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;
namespace BLL
{
    public interface IUserProvider
    {
        IQueryable<Users> GetAllUsers();
        Users GetUserById(int id);
        void AddUser(Users user);
        void EditUser(Users user);
        void DeleteUser(int id);
    }
}
