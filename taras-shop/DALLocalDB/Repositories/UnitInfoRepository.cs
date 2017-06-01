using System.Linq;

namespace DALLocalDB.Repositories
{
    public class UnitInfoRepository : IRepository.IRepository<UnitInfo>
    {
        public UnitInfoRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(UnitInfo item)
        {
            return entities.UnitInfoes.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.UnitInfoes.FirstOrDefault(x => x.id == id);
            entities.UnitInfoes.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(UnitInfo item)
        {
            entities.UnitInfoes.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<UnitInfo> GetAll()
        {
            return entities.UnitInfoes;
        }

        public override UnitInfo GetById(int id)
        {
            return entities.UnitInfoes.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
