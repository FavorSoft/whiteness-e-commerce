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
        public NewsImageRepository(Entities db) : base(db)
        {
        }

        public override void AddItem(News_image item)
        {
            entities.News_image.Add(item);
        }

        public override void DeleteItem(int id)
        {
            var item = entities.News_image.FirstOrDefault(x => x.id == id);
            entities.News_image.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(News_image item)
        {
            entities.News_image.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<News_image> GetAll()
        {
            return entities.News_image;
        }

        public override News_image GetById(int id)
        {
            return entities.News_image.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
