using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepositiry
    {
        Entities entities;
        public UserRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Users item)
        {
            entities.Users.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Users.Remove(new Users() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Users item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetAll()
        {
            return entities.Users;
        }

        public Users GetById(int id)
        {
            return entities.Users.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
