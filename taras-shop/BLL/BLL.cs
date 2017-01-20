using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Helpers;

namespace BLL
{
    public class BLL : IBLL
    {
        IDatabase _IDatabase;
        public BLL()
        {
            _IDatabase = new MSSQLDatabase();
        }

        public IEnumerable<DTO.Helpers.Basket> GetAllBaskets()
        {
            List<DTO.Helpers.Basket> baskets = new List<DTO.Helpers.Basket>();
            foreach (var i in _IDatabase.GetAllBaskets().ToList())
            {
                baskets.Add(Converter.SqlBasketToDTOBasket(i));
            }
            return baskets;
        }

        public IEnumerable<DTO.Helpers.Categories> GetAllCategories()
        {
            List<DTO.Helpers.Categories> categories = new List<DTO.Helpers.Categories>();
            foreach (var i in _IDatabase.GetAllCategories().ToList())
            {
                categories.Add(Converter.SqlCategoriesToDTOCategories(i));
            }
            return categories;
        }

        public IEnumerable<DTO.Helpers.News> GetAllNews()
        {
            List<DTO.Helpers.News> news = new List<DTO.Helpers.News>();
            foreach (var i in _IDatabase.GetAllNews().ToList())
            {
                news.Add(Converter.SqlNewsToDTONews(i));
            }
            return news;
        }

        public IEnumerable<News_images> GetAllNewsImages()
        {
            List<DTO.Helpers.News_images> news_images = new List<DTO.Helpers.News_images>();
            foreach (var i in _IDatabase.GetAllNewsImages().ToList())
            {
                news_images.Add(Converter.SqlNews_imagesToDTONews_images(i));
            }
            return news_images;
        }

        public IEnumerable<DTO.Helpers.Roles> GetAllRoles()
        {
            List<DTO.Helpers.Roles> roles = new List<DTO.Helpers.Roles>();
            foreach (var i in _IDatabase.GetAllRoles().ToList())
            {
                roles.Add(Converter.SqlRolesToDTORoles(i));
            }
            return roles;
        }

        public IEnumerable<DTO.Helpers.Unit> GetAllUnits()
        {
            List<DTO.Helpers.Unit> units = new List<DTO.Helpers.Unit>();
            foreach (var i in _IDatabase.GetAllUnits().ToList())
            {
                units.Add(Converter.SqlUnitToDTOUnit(i));
            }
            return units;
        }

        public IEnumerable<DTO.Helpers.Users> GetAllUsers()
        {
            List<DTO.Helpers.Users> users = new List<DTO.Helpers.Users>();
            foreach (var i in _IDatabase.GetAllUsers().ToList())
            {
                users.Add(Converter.SqlUsersToDTOUsers(i));
            }
            return users;
        }
    }
}
