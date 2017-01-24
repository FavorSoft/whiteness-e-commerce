using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository:IUserRepository
    {
        SqlEntities entity;
        public UserRepository()
        {
            entity = new SqlEntities();
        }
        public IQueryable<Users> GetAllUsers()
        {
            return entity.Users;
        }

        public Users GetUserById(int id)
        {
            return entity.Users.Where(x => x.id == id).FirstOrDefault();
        }

        public void AddUser(Users user)
        {
            entity.Users.Add(user);
            entity.SaveChanges();
        }

        public void EditUser(Users user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            entity.Users.Remove(new Users() { id = id });
            entity.SaveChanges();
        }
    }
}
