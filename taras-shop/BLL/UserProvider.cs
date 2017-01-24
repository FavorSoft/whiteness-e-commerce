using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserProvider : IUserProvider
    {
        IUserRepository _repo;
        public UserProvider()
        {
            _repo = new UserRepository();
        }
        public IQueryable<DTO.Helpers.Users> GetAllUsers()
        {
            return null;
        }

        public DTO.Helpers.Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(DTO.Helpers.Users user)
        {
            _repo.AddUser(new DAL.Users() 
            { 
                name = user.Name,
                number = user.Number,
                password = user.Password,
                reg_date = user.Reg_date,
                role_id = user.Role_id,
                surname = user.Surname,
                email = user.Email      
            });
        }

        public void EditUser(DTO.Helpers.Users user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            _repo.DeleteUser(id);
        }
    }
}
