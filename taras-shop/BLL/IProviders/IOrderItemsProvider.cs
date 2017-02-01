using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IOrderItemsProvider
    {
        void AddItem(DTO.OrderItemsDto category);
        IEnumerable<DTO.OrderItemsDto> GetAll();
        DTO.OrderItemsDto GetById(int id);
    }
}
