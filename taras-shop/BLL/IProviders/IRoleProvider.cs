using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IRoleProvider
    {
        void AddItem(DTO.Roles category);
        IEnumerable<DTO.Roles> GetAll();
        DTO.Roles GetById(int id);
    }
}
