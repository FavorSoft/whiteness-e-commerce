using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public abstract class IRepository<T>
    {
        protected Entities entities;
        public IRepository(Entities db)
        {
            entities = db;
        }

        public Entities GetEntities() {
            return entities;
        }
        public abstract void AddItem(T item);
        public abstract IQueryable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void EditItem(T item);
        public abstract void DeleteItem(int id);
        public abstract T GetByInfo(string title, int id);
    }
}
