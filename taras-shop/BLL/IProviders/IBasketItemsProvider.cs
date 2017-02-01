using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketItemsProvider
    {
        void AddItem(DTO.BasketItemsDto basketItems);
        IEnumerable<DTO.BasketItemsDto> GetAll();
        DTO.BasketItemsDto GetById(int id);
    }
}
