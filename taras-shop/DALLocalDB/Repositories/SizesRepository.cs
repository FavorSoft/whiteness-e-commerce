using System.Linq;

namespace DALLocalDB.Repositories
{
    public class SizesRepository : IRepository.IRepository<Size>
    {
        public SizesRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Size item)
        {
            return entities.Size.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Size.FirstOrDefault(x => x.id == id);
            entities.Size.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Size item)
        {
            entities.Size.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Size> GetAll()
        {
            return entities.Size;
        }

        public override Size GetById(int id)
        {
            return entities.Size.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
