using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBasketItemsRepository
    {
        void AddItem(Basket_items item);
        IQueryable<Basket_items> GetAll();
        Basket_items GetById(int id);
        void EditItem(Basket_items item);
        void DeleteItem(int id);
    }
}
