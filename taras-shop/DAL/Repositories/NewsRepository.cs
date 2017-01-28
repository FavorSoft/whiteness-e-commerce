using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {
        SqlEntities entities;
        public NewsRepository()
        {
            entities = new SqlEntities();
        }
        public void AddItem(News item)
        {
            entities.News.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.News.Remove(new News() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(News item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<News> GetAll()
        {
            return entities.News;
        }

        public News GetById(int id)
        {
            return entities.News.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
