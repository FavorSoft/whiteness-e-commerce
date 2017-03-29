﻿using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public OrderRepository(LocalEntities db) : base(db)
        {
        }

        public override void AddItem(Order item)
        {
            entities.Order.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Order.FirstOrDefault(x => x.id == id);
            entities.Order.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Order item)
        {
            entities.Order.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }

        public override IQueryable<Order> GetAll()
        {
            return entities.Order;
        }

        public override Order GetById(int id)
        {
            return entities.Order.Where(x => x.id == id).FirstOrDefault();
        }
    }
}