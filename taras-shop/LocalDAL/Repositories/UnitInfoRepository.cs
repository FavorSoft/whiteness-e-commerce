using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitInfoRepository : IRepository.IRepository<UnitInfo>
    {
        LocalEntities entities;
        public UnitInfoRepository(LocalEntities db)
        {
            entities = db;
        }
        public void AddItem(UnitInfo item)
        {
            entities.UnitInfo.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.UnitInfo.FirstOrDefault(x => x.id == id);
            entities.UnitInfo.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(UnitInfo item)
        {
            entities.UnitInfo.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<UnitInfo> GetAll()
        {
            return entities.UnitInfo;
        }

        public UnitInfo GetById(int id)
        {
            return entities.UnitInfo.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
