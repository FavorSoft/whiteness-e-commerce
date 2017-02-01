using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUserProvider
    {
        void AddItem(DTO.UsersDto category);
        IEnumerable<DTO.UsersDto> GetAll();
        DTO.UsersDto GetById(int id);
    }
}
