using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SizesRepository : IRepository.IRepository<Sizes>
    {
        Entities entities;
        public SizesRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Sizes item)
        {
            entities.Sizes.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Sizes.Remove(new Sizes() { id = id });
        }

        public void EditItem(Sizes item)
        {
            throw new NotImplementedException();
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
