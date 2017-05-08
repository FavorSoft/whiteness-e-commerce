using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class BasketRepository : IRepository<Basket>
    {
        public BasketRepository(LocalEntities db) : base(db)
        {
        }

        public override int AddItem(Basket item)
        {
            return entities.Basket.Add(item).id;
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
