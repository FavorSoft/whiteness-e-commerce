using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class ImagesRepository : IRepository<Images>
    {
        public ImagesRepository(LocalEntities db) : base(db)
        {
        }

        public override void AddItem(Images item)
        {
            entities.Images.Add(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Images.FirstOrDefault(x => x.id == id);
            entities.Images.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Images item)
        {
            entities.Images.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Images> GetAll()
        {
            return entities.Images;
        }

        public override Images GetById(int id)
        {
            return entities.Images.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
