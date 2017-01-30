using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BasketItemsRepository : IBasketItemsRepository
    {
        Entities entities;
        public BasketItemsRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Basket_items item)
        {
            entities.Basket_items.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Basket_items.Remove(new Basket_items() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Basket_items item)
        {
            //help
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
