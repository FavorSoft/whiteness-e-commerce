using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public OrderRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Order item)
        {
            return entities.Orders.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Orders.FirstOrDefault(x => x.id == id);
            entities.Orders.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Order item)
        {
            entities.Orders.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;

        }

        public override IQueryable<Order> GetAll()
        {
            return entities.Orders;
        }

        public override Order GetById(int id)
        {
            return entities.Orders.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
