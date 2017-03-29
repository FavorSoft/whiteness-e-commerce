﻿using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class UnitRepository : IRepository<Unit>
    {
        public UnitRepository(LocalEntities db) : base(db)
        {

        }

        public override void AddItem(Unit item)
        {
            entities.Unit.Add(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Unit.FirstOrDefault(x => x.id == id);
            entities.Unit.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Unit item)
        {
            entities.Unit.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Unit> GetAll()
        {
            return entities.Unit;
        }

        public override Unit GetById(int id)
        {
            return entities.Unit.Where(x => x.id == id).FirstOrDefault();
        }
    }
}