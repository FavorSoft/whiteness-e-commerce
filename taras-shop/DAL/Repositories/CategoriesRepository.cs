using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        Entities entities;
        public CategoriesRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Categories item)
        {
            entities.Categories.Add(item);
        }

        public void DeleteItem(int id)
        {
            entities.Categories.Remove(new Categories() { id = id });
        }

        public void EditItem(Categories item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Categories> GetAll()
        {
            return entities.Categories.AsQueryable();
        }

        public Categories GetById(int id)
        {
            return entities.Categories.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
