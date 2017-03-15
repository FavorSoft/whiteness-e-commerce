using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SizesRepository : IRepository.IRepository<Sizes>
    {
        LocalEntities entities;
        public SizesRepository(LocalEntities db)
        {
            entities = db;
        }
        public void AddItem(Sizes item)
        {
            entities.Sizes.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.Sizes.FirstOrDefault(x => x.id == id);
            entities.Sizes.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(Sizes item)
        {
            entities.Sizes.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<Sizes> GetAll()
        {
            return entities.Sizes;
        }

        public Sizes GetById(int id)
        {
            return entities.Sizes.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
