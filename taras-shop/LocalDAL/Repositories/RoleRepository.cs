using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RoleRepository : IRepository<Roles>
    {
        LocalEntities entities;
        public RoleRepository(LocalEntities db)
        {
            entities = db;
        }
        public void AddItem(Roles item)
        {
            entities.Roles.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Roles.FirstOrDefault(x => x.id == id);
            entities.Roles.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Roles item)
        {
            entities.Roles.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }

        public IQueryable<Roles> GetAll()
        {
            return entities.Roles;
        }

        public Roles GetById(int id)
        {
            return entities.Roles.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
