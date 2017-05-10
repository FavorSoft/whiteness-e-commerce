using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        public RoleRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Role item)
        {
            return entities.Role.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Role.FirstOrDefault(x => x.id == id);
            entities.Role.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Role item)
        {
            entities.Role.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }

        public override IQueryable<Role> GetAll()
        {
            return entities.Role;
        }

        public override Role GetById(int id)
        {
            return entities.Role.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
