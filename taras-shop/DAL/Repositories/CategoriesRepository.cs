using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoriesRepository : IRepository<Categories>
    {
        Entities entities;
        public CategoriesRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Categories item)
        {
            entities.Categories.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Categories.FirstOrDefault(x => x.id == id);
            entities.Categories.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Categories item)
        {
            entities.Categories.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<Categories> GetAll()
        {
            return entities.Categories.AsQueryable();
        }

        public Categories GetById(int id)
        {
            return entities.Categories.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
