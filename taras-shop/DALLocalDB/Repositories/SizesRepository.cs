using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repositories
{
    public class SizesRepository : IRepository<Size>
    {
        public SizesRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Size item)
        {
            return entities.Sizes.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Sizes.FirstOrDefault(x => x.id == id);
            entities.Sizes.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Size item)
        {
            entities.Sizes.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Size> GetAll()
        {
            return entities.Sizes;
        }

        public override Size GetById(int id)
        {
            return entities.Sizes.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
