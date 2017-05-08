using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class RoleRepository : IRepository<Roles>
    {
        public RoleRepository(LocalEntities db) : base(db)
        {
        }

        public override int AddItem(Roles item)
        {
            return entities.Roles.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Roles.FirstOrDefault(x => x.id == id);
            entities.Roles.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Roles item)
        {
            entities.Roles.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }

        public override IQueryable<Roles> GetAll()
        {
            return entities.Roles;
        }

        public override Roles GetById(int id)
        {
            return entities.Roles.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
