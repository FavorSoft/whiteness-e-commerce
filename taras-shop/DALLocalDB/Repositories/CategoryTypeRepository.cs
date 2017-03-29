﻿using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class CategoryTypeRepository : IRepository<Category_type>
    {
        public CategoryTypeRepository(LocalEntities db) : base(db)
        {
        }

        public override void AddItem(Category_type item)
        {
            entities.Category_type.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Category_type.FirstOrDefault(x => x.id == id);
            entities.Category_type.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Category_type item)
        {
            entities.Category_type.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Category_type> GetAll()
        {
            return entities.Category_type;
        }

        public override Category_type GetById(int id)
        {
            return entities.Category_type.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
