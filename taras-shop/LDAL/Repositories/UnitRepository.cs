using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitRepository : IUnitRepository
    {
        Entities entities;
        public UnitRepository(Entities db)
        {
            entities = db;
        }

        public Entities GetEntities { get { return entities; } }

        public void AddItem(Unit item)
        {
            entities.Unit.Add(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public void DeleteItem(int id)
        {
            var item = entities.Unit.FirstOrDefault(x => x.id == id);
            entities.Unit.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Unit item)
        {
            entities.Unit.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
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
