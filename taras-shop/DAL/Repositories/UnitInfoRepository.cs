using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitInfoRepository : IRepository.IRepository<UnitInfo>
    {
        Entities entities;
        public UnitInfoRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(UnitInfo item)
        {
            entities.UnitInfo.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.UnitInfo.Remove(new UnitInfo()
            {
                id = id
            });
        }

        public void EditItem(UnitInfo item)
        {
            
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
