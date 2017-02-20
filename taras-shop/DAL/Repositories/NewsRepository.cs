﻿using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class NewsRepository : IRepository<News>
    {
        Entities entities;
        public NewsRepository(Entities db)
        {
            entities = db;
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
