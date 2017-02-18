using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ImagesRepository : IRepository<Images>
    {
        Entities entities;
        public ImagesRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(Images item)
        {
            entities.Images.Add(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public void DeleteItem(int id)
        {
            entities.Images.Remove(new Images() { id = id });
        }

        public void EditItem(Images item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Images> GetAll()
        {
            return entities.Images;
        }

        public Images GetById(int id)
        {
            return entities.Images.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
