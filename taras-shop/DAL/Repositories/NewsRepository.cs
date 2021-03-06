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
        public NewsRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(News item)
        {
            entities.News.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.News.FirstOrDefault(x => x.id == id);
            entities.News.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(News item)
        {
            entities.News.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<News> GetAll()
        {
            return entities.News;
        }

        public override News GetById(int id)
        {
            return entities.News.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
