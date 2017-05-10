using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class NewsRepository : IRepository<News>
    {
        public NewsRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(News item)
        {
            return entities.News.Add(item).id;
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
