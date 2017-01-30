using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryTypeRepository : ICategoryTypeRepository
    {
        Entities entities;
        public CategoryTypeRepository()
        {
            entities = new Entities();
        }
        public void AddItem(Category_type item)
        {
            entities.Category_type.Add(item);
            entities.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            entities.Category_type.Remove(new Category_type() { id = id });
            entities.SaveChanges();
        }

        public void EditItem(Category_type item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category_type> GetAll()
        {
            return entities.Category_type;
        }

        public Category_type GetById(int id)
        {
            return entities.Category_type.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
