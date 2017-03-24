using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitInfoRepository : IRepository.IRepository<UnitInfo>
    {
        public UnitInfoRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(UnitInfo item)
        {
            entities.UnitInfo.Add(item);
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
