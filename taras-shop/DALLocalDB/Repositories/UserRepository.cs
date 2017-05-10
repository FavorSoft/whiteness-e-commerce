using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class UserRepository : IRepository<User>
    {
        public UserRepository(AzureEntities db) : base(db)
        {
        }
        
        public override int AddItem(User item)
        {
            return entities.User.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.User.FirstOrDefault(x => x.id == id);
            entities.User.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(User item)
        {
            var tmp = entities.User.Where(x => x.id == item.id);
            entities.Entry(tmp).CurrentValues.SetValues(item);
        }

        public override IQueryable<User> GetAll()
        {
            return entities.User;
        }

        public override User GetById(int id)
        {
            return entities.User.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
