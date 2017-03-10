using DAL.IRepository;
using Microsoft.AspNet.Identity;
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
            var item = entities.Users.FirstOrDefault(x => x.id == id);
            entities.Users.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Users item)
        {
            entities.Users.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

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
