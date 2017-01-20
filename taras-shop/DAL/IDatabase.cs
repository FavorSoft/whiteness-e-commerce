using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDatabase
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Unit> GetAllUnits();
        IEnumerable<Roles> GetAllRoles();
        IEnumerable<Basket> GetAllBaskets();
        IEnumerable<News> GetAllNews();
        IEnumerable<News_image> GetAllNewsImages();
        IEnumerable<Categories> GetAllCategories();
    }
}
