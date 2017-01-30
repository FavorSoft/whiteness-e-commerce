using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        Entities entities;
        public OrderRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Order item)
        {
            entities.Order.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Order.Remove(new Order() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Order item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            return entities.Order;
        }

        public Order GetById(int id)
        {
            return entities.Order.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
