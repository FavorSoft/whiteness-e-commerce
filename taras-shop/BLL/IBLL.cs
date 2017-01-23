using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;

namespace BLL
{
    public interface IBLL
    {
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Unit> GetAllUnits();
        IEnumerable<Roles> GetAllRoles();
        IEnumerable<Basket> GetAllBaskets();
        IEnumerable<News> GetAllNews();
        IEnumerable<News_images> GetAllNewsImages();
        IEnumerable<Categories> GetAllCategories();
    }
}
