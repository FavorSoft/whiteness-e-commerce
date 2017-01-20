using System;
using System.Collections.Generic;

namespace DAL
{
    public class MSSQLDatabase : IDatabase
    {
        private SqlEntities entities;
        public MSSQLDatabase()
        {
            entities = new SqlEntities();
        }

        public void AddBasket(Basket basket)
        {
            entities.Basket.Add(basket);
            entities.SaveChanges();
        }

        public void AddCategories(Categories category)
        {
            entities.Categories.Add(category);
            entities.SaveChanges();
        }

        public void AddNews(News news)
        {
            entities.News.Add(news);
            entities.SaveChanges();
        }

        public void AddNewsImage(News_image newsImage)
        {
            entities.NewsImage.Add(newsImage);
            entities.SaveChanges();
        }

        public void AddRole(Roles role)
        {
            entities.Roles.Add(role);
            entities.SaveChanges();
        }

        public void AddUnit(Unit unit)
        {
            entities.Unit.Add(unit);
            entities.SaveChanges();
        }

        public void AddUser(Users user)
        {
            entities.Users.Add(user);
            entities.SaveChanges();
        }

        public IEnumerable<Basket> GetAllBaskets()
        {
            return entities.Basket.;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return entities.Categories;
        }

        public IEnumerable<News> GetAllNews()
        {
            return entities.News;
        }

        public IEnumerable<News_image> GetAllNewsImages()
        {
            return entities.NewsImage;
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return entities.Roles;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return entities.Unit;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return entities.Users;
        }

        public Basket GetBasketById(int id)
        {
            return entities.Basket.Find();
        }

        public Categories GetCategoriesById(int id)
        {
            return 
        }

        public News GetNewsById(int id)
        {
            throw new NotImplementedException();
        }

        public News_image GetNewsImageById(int id)
        {
            throw new NotImplementedException();
        }

        public Roles GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Unit GetUnitById(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
