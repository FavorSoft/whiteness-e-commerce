using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderItemsRepository
    {
        void AddItem(Order_items item);
        IQueryable<Order_items> GetAll();
        Order_items GetById(int id);
        void EditItem(Order_items item);
        void DeleteItem(int id);
    }
}
