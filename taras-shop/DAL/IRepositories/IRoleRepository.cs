using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRoleRepository
    {
        void AddItem(Roles item);
        IQueryable<Roles> GetAll();
        Roles GetById(int id);
        void EditItem(Roles item);
        void DeleteItem(int id);
    }
}
