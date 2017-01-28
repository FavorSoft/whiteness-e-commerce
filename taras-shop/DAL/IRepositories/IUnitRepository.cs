using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitRepository
    {
        void AddItem(Unit item);
        IQueryable<Unit> GetAll();
        Unit GetById(int id);
        void EditItem(Unit item);
        void DeleteItem(int id);
    }
}
