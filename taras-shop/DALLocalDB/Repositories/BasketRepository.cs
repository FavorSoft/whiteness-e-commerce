using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class BasketRepository : IRepository<Basket>
    {
        public BasketRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Basket item)
        {
            return entities.Baskets.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Baskets.FirstOrDefault(x => x.id == id);
            entities.Baskets.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Basket item)
        {
            entities.Baskets.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Basket> GetAll()
        {
            return entities.Baskets;
        }

        public override Basket GetById(int id)
        {
            return entities.Baskets.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
