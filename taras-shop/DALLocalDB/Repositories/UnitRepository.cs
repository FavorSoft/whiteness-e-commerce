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
            return entities.Units.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Units.FirstOrDefault(x => x.id == id);
            entities.Units.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Unit item)
        {
            entities.Units.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Unit> GetAll()
        {
            return entities.Units;
        }

        public override Unit GetById(int id)
        {
            return entities.Units.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
