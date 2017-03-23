using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class NewsImageRepository : IRepository<News_image>
    {
        Entities entities;
        public NewsImageRepository(Entities db)
        {
            entities = db;
        }
        public void AddItem(News_image item)
        {
            entities.News_image.Add(item);
        }

        public void DeleteItem(int id)
        {
            var item = entities.News_image.FirstOrDefault(x => x.id == id);
            entities.News_image.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public void EditItem(News_image item)
        {
            entities.News_image.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
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
