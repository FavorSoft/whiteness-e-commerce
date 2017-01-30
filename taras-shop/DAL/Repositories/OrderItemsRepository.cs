using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        Entities entities;
        public OrderItemsRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Order_items item)
        {
            entities.Order_items.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Order_items.Remove(new Order_items() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Order_items item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order_items> GetAll()
        {
            return entities.Order_items;
        }

        public Order_items GetById(int id)
        {
            return entities.Order_items.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
