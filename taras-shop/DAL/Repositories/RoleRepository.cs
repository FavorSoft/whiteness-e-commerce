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
        Entities entities;
        public RoleRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Roles item)
        {
            entities.Roles.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Roles.Remove(new Roles() { id = id });
        }

        public void EditItem(Roles item)
        {
            throw new NotImplementedException();
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
