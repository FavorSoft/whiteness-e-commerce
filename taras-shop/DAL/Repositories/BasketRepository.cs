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
        public BasketRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(Basket item)
        {
            entities.Basket.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Basket.FirstOrDefault(x => x.id == id);
            entities.Basket.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Basket item)
        {
            entities.Basket.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Basket> GetAll()
        {
            return entities.Basket;
        }

        public override Basket GetById(int id)
        {
            return entities.Basket.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
