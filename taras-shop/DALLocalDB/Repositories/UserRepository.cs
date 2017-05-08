using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class UserRepository : IRepository<Users>
    {
        public UserRepository(LocalEntities db) : base(db)
        {
        }
        
        public override int AddItem(Users item)
        {
            return entities.Users.Add(item).id;
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
