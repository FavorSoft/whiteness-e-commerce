using DALLocalDB.IRepository;
using System.Linq;

namespace DALLocalDB.Repository
{
    public class CategoriesRepository : IRepository<Category>
    {
        public CategoriesRepository(AzureEntities db) : base(db)
        {
        }

        public override int AddItem(Category item)
        {
            return entities.Categories.Add(item).id;
        }

        public override void DeleteItem(int id)
        {
            var item = entities.Categories.FirstOrDefault(x => x.id == id);
            entities.Categories.Remove(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public override void EditItem(Category item)
        {
            entities.Categories.Attach(item);
            entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public override IQueryable<Category> GetAll()
        {
            return entities.Categories.AsQueryable();
        }

        public override Category GetById(int id)
        {
            return entities.Categories.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
 