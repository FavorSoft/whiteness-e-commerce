using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderRepository
    {
        void AddItem(Order item);
        IQueryable<Order> GetAll();
        Order GetById(int id);
        void EditItem(Order item);
        void DeleteItem(int id);
    }
}
