using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INewsRepository
    {
        void AddItem(News item);
        IQueryable<News> GetAll();
        News GetById(int id);
        void EditItem(News item);
        void DeleteItem(int id);
    }
}
