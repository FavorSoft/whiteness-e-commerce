using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        Entities entities;
        public UnitRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Unit item)
        {
            entities.Unit.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Unit.Remove(new Unit() { id = id });
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
