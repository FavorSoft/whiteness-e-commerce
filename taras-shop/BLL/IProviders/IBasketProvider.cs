using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IBasketProvider
    {
        void AddItem(DTO.Basket basket);
        List<DTO.Basket> GetAll();
        DTO.Basket GetById(int id);
    }
}
