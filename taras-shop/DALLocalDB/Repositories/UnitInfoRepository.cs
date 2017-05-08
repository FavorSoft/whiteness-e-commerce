using System.Linq;

namespace DALLocalDB.Repositories
{
    public class UnitInfoRepository : IRepository.IRepository<UnitInfo>
    {
        public UnitInfoRepository(LocalEntities db) : base(db)
        {
        }

        public override int AddItem(UnitInfo item)
        {
            return entities.UnitInfo.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.UnitInfo.FirstOrDefault(x => x.id == id);
            entities.UnitInfo.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(UnitInfo item)
        {
            entities.UnitInfo.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<UnitInfo> GetAll()
        {
            return entities.UnitInfo;
        }

        public override UnitInfo GetById(int id)
        {
            return entities.UnitInfo.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
