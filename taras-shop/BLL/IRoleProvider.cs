using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;
namespace BLL
{
    public interface IRoleProvider
    {
        IQueryable<Roles> GetAllRoles();
        Roles GetRoleById(int id);
        void AddRole(Roles role);
        void EditRole(Roles role);
        void DeleteRole(int id);   
    }
}
