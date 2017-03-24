using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderItemsRepository : IRepository<Order_items>
    {
        Entities entities;
        public OrderItemsRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Order_items item)
        {
            entities.Order_items.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Order_items.FirstOrDefault(x => x.id == id);
            entities.Order_items.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Order_items item)
        {
            entities.Order_items.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
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
