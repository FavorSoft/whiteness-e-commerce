using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleRepository:IRoleRepository
    {
        SqlEntities entity;
        public RoleRepository()
        {
            entity = new SqlEntities();
        }
        public IQueryable<Roles> GetAllRoles()
        {
            return entity.Roles;
        }

        public Roles GetRoleById(int id)
        {
            return entity.Roles.Where(x => x.id == id).FirstOrDefault();
        }

        public void AddRole(Roles role)
        {
            entity.Roles.Add(role);
            entity.SaveChanges();
        }

        public void EditRole(Roles role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(int id)
        {
            entity.Roles.Remove(new Roles() { id = id });
            entity.SaveChanges();
        }
    }
}
