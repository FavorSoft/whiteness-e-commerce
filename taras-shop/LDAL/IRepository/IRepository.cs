using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IRepository<T>
    {
        void AddItem(T item);
        IQueryable<T> GetAll();
        T GetById(int id);
        void EditItem(T item);
        void DeleteItem(int id);
    }
}
