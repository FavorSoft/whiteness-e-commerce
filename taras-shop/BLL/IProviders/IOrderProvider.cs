using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IOrderProvider
    {
        void AddItem(DTO.OrderDto category);
        IEnumerable<DTO.OrderDto> GetAll();
        DTO.OrderDto GetById(int id);
    }
}
