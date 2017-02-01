using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IRoleProvider
    {
        void AddItem(DTO.RolesDto category);
        IEnumerable<DTO.RolesDto> GetAll();
        DTO.RolesDto GetById(int id);
    }
}
