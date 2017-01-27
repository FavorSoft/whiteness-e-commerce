using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INewsImageRepository
    {
        void AddItem(News_image item);
        IQueryable<News_image> GetAll();
        News_image GetById(int id);
        void EditItem(News_image item);
        void DeleteItem(int id);
    }
}
