using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IRepository<Users>
    {
        Entities entities;
        public UserRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Users item)
        {
            entities.Users.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Users.Remove(new Users() { id = id });
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
