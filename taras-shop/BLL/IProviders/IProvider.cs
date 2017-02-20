using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IProvider<T>
    {
        void AddItem(T category);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
