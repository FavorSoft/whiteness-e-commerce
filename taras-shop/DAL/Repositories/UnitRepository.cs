using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        SqlEntities entities;
        public UnitRepository()
        {
            entities = new SqlEntities();
        }
        public void AddItem(Unit item)
        {
            entities.Unit.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Unit.Remove(new Unit() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Unit item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Unit> GetAll()
        {
            return entities.Unit;
        }

        public Unit GetById(int id)
        {
            return entities.Unit.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
