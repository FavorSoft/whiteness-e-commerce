using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleProvider:IRoleProvider
    {
        IRoleRepository _repo;
        public RoleProvider()
        {
            _repo = new RoleRepository();
        }
        public IQueryable<DTO.Helpers.Roles> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public DTO.Helpers.Roles GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRole(DTO.Helpers.Roles role)
        {
            _repo.AddRole(new DAL.Roles()
            {
                role = role.Role
            });
        }

        public void EditRole(DTO.Helpers.Roles role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(int id)
        {
            _repo.DeleteRole(id);
        }
    }
}
