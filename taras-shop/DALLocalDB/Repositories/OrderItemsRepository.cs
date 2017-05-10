using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class OrderItemsRepository : IRepository<Order_items>
    {
        public OrderItemsRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Order_items item)
        {
            return entities.Order_items.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Order_items.FirstOrDefault(x => x.id == id);
            entities.Order_items.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Order_items item)
        {
            entities.Order_items.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Order_items> GetAll()
        {
            return entities.Order_items;
        }

        public override Order_items GetById(int id)
        {
            return entities.Order_items.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
