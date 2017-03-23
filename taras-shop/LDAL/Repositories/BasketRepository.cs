using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BasketRepository : IRepository<Basket>
    {
        Entities entities;
        public BasketRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Basket item)
        {
            entities.Basket.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Basket.FirstOrDefault(x => x.id == id);
            entities.Basket.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Basket item)
        {
            entities.Basket.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<Basket> GetAll()
        {
            return entities.Basket;
        }

        public Basket GetById(int id)
        {
            return entities.Basket.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
