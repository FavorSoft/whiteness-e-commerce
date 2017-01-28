using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoriesRepository
    {
        void AddItem(Categories item);
        IQueryable<Categories> GetAll();
        Categories GetById(int id);
        void EditItem(Categories item);
        void DeleteItem(int id);
    }
}
