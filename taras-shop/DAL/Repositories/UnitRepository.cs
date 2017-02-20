using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitRepository : IRepository<Unit>
    {
        Entities entities;
        public UnitRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Unit item)
        {
            entities.Unit.Add(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Added;
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
