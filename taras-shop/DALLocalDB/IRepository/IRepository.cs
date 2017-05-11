using System.Linq;

namespace DALLocalDB.IRepository
{
    public abstract class IRepository<T>
    {
        protected AzureEntities entities;
        public IRepository(AzureEntities db)
        {
            entities = db;
        }

        public AzureEntities GetEntities() {
            return entities;
        }
        public abstract int AddItem(T item);
        public abstract IQueryable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void EditItem(T item);
        public abstract void DeleteItem(int id);
    }
}
