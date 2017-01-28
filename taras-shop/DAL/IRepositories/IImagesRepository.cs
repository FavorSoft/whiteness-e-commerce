using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IImagesRepository
    {
        void AddItem(Images item);
        IQueryable<Images> GetAll();
        Images GetById(int id);
        void EditItem(Images item);
        void DeleteItem(int id);
    }
}
