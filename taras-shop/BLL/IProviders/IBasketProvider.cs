using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketProvider
    {
        void AddItem(DTO.BasketDto basket);
        IEnumerable<DTO.BasketDto> GetAll();
        DTO.BasketDto GetById(int id);
    }
}
