using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        Entities entities;
        public BasketRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Basket item)
        {
            entities.Basket.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Basket.Remove(new Basket() { id = id });
        }

        public void EditItem(Basket item)
        {
            entities.Basket.Select(x => x.id == item.id).FirstOrDefault();
            //help
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
