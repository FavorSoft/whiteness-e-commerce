using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketItemsProvider : IProvider<BasketItemsDto>
    {
        IEnumerable<BasketItemsDto> GetByBasket(BasketDto basket);
        IEnumerable<BasketItemsDto> GetByInfo(int unitId, string size, int basketId);
        void DeleteByInfo(int unitId, string size, int basketId);
    }
}
