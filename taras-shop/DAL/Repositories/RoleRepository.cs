using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        SqlEntities entities;
        public RoleRepository()
        {
            entities = new SqlEntities();
        }
        public void AddItem(Roles item)
        {
            entities.Roles.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Roles.Remove(new Roles() { id = id });
            entities.SaveChanges();
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
