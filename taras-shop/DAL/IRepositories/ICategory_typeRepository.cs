using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoryTypeRepository
    {
        void AddItem(Category_type item);
        IQueryable<Category_type> GetAll();
        Category_type GetById(int id);
        void EditItem(Category_type item);
        void DeleteItem(int id);
    }
}
