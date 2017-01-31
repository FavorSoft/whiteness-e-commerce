using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUserProvider
    {
        void AddItem(DTO.Users category);
        IEnumerable<DTO.Users> GetAll();
        DTO.Users GetById(int id);
    }
}
