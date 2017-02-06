using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {
        Entities entities;
        public NewsRepository()
        {
            entities = new Entities();
        }
        public void AddItem(News item)
        {
            entities.News.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.News.Remove(new News() { id = id });
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
