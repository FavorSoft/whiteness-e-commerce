using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBasketRepository
    {
        void AddItem(Basket item);
        IQueryable<Basket> GetAll();
        Basket GetById(int id);
        void EditItem(Basket item);
        void DeleteItem(int id);
    }
}
