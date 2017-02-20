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
        Entities entities;
        public BasketItemsRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Basket_items item)
        {
            entities.Basket_items.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Basket_items.Remove(new Basket_items() { id = id });
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
