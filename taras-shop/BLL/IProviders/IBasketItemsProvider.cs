using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketItemsProvider
    {
        void AddItem(DTO.BasketItems basketItems);
        IEnumerable<DTO.BasketItems> GetAll();
        DTO.BasketItems GetById(int id);
    }
}
