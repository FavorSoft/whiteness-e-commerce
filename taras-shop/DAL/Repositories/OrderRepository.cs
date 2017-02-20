using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        Entities entities;
        public OrderRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Order item)
        {
            entities.Order.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Order.Remove(new Order() { id = id });
            
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
