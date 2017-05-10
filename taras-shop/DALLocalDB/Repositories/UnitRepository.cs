using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class UnitRepository : IRepository<Unit>
    {
        public UnitRepository(AzureEntities db) : base(db)
        {

        }

        public override int AddItem(Unit item)
        {
            return entities.Unit.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Unit.FirstOrDefault(x => x.id == id);
            entities.Unit.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Unit item)
        {
            entities.Unit.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Unit> GetAll()
        {
            return entities.Unit;
        }

        public override Unit GetById(int id)
        {
            return entities.Unit.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
