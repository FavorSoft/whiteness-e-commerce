using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NewsImage : INewsImageRepository
    {
        Entities entities;
        public NewsImage()
        {
            entities = new Entities();
        }
        public void AddItem(News_image item)
        {
            entities.News_image.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.News_image.Remove(new News_image() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(News_image item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<News_image> GetAll()
        {
            return entities.News_image;
        }

        public News_image GetById(int id)
        {
            return entities.News_image.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
