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
        public UserRepository(Entities db) : base(db)
        {
        }
        
        public override void AddItem(Users item)
        {
            entities.Users.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Users.FirstOrDefault(x => x.id == id);
            entities.Users.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Users item)
        {
            var tmp = entities.Users.Where(x => x.id == item.id);
            entities.Entry(tmp).CurrentValues.SetValues(item);
        }

        public override IQueryable<Users> GetAll()
        {
            return entities.Users;
        }

        public override Users GetById(int id)
        {
            return entities.Users.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
