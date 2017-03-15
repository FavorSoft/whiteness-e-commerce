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
        LocalEntities entities;
        public OrderRepository(LocalEntities db)
        {
            entities = db;
        }
        public void AddItem(Order item)
        {
            entities.Order.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Order.FirstOrDefault(x => x.id == id);
            entities.Order.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Order item)
        {
            entities.Order.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

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
