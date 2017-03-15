using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IRepository;
namespace DAL.Repository
{
    public class BasketItemsRepository : IRepository<Basket_items>
    {
        LocalEntities entities;
        public BasketItemsRepository(LocalEntities db)
        {
            entities = db;
        }
        public void AddItem(Basket_items item)
        {
            entities.Basket_items.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Basket_items.FirstOrDefault(x => x.id == id);
            entities.Basket_items.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Basket_items item)
        {
            entities.Basket_items.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<Basket_items> GetAll()
        {
            return entities.Basket_items;
        }

        public Basket_items GetById(int id)
        {
            return entities.Basket_items.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
