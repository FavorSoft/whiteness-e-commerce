using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRoleRepository
    {
        IQueryable<Roles> GetAllRoles();
        Roles GetRoleById(int id);
        void AddRole(Roles role);
        void EditRole(Roles role);
        void DeleteRole(int id);
    }
}
