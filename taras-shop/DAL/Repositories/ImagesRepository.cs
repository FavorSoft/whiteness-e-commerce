using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        SqlEntities entities;
        public ImagesRepository()
        {
            entities = new SqlEntities();
        }
        public void AddItem(Images item)
        {
            entities.Images.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Images.Remove(new Images() { id = id });
            entities.SaveChanges();
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
