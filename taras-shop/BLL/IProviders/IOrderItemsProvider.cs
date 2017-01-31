using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IOrderItemsProvider
    {
        void AddItem(DTO.OrderItems category);
        IEnumerable<DTO.OrderItems> GetAll();
        DTO.OrderItems GetById(int id);
    }
}
