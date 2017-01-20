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
        Users GetUserById(int id);
        IEnumerable<Unit> GetAllUnits();
        Unit GetUnitById(int id);
        IEnumerable<Roles> GetAllRoles();
        Roles GetRoleById(int id);
        IEnumerable<Basket> GetAllBaskets();
        Basket GetBasketById(int id);
        IEnumerable<News> GetAllNews();
        News GetNewsById(int id);
        IEnumerable<News_image> GetAllNewsImages();
        News_image GetNewsImageById(int id);
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoriesById(int id);
        void AddUser(Users user);
        void AddUnit(Unit unit);
        void AddRole(Roles role);
        void AddBasket(Basket basket);
        void AddNews(News news);
        void AddNewsImage(News_image newsImage);
        void AddCategories(Categories category);
    }
}
