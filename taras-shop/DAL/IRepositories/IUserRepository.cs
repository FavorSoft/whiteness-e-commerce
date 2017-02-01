using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserRepository
    {
        void AddItem(Users item);
        IQueryable<Users> GetAll();
        Users GetById(int id);
        void EditItem(Users item);
        void DeleteItem(int id);
    }
}
