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
        public CategoriesRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(Categories item)
        {
            entities.Categories.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Categories.FirstOrDefault(x => x.id == id);
            entities.Categories.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Categories item)
        {
            entities.Categories.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Categories> GetAll()
        {
            return entities.Categories.AsQueryable();
        }

        public override Categories GetById(int id)
        {
            return entities.Categories.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
 