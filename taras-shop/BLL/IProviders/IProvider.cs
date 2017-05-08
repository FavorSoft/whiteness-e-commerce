using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface IProvider<T>
    {
        int AddItem(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void DeleteItem(int id);
        void EditItem(T item);
    }
}
