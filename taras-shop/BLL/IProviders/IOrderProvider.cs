using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IOrderProvider
    {
        void AddItem(DTO.Order category);
        IEnumerable<DTO.Order> GetAll();
        DTO.Order GetById(int id);
    }
}
