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

        public IEnumerable<Basket> GetAllBasket()
        {
            return entities.Basket;
        }

        public IEnumerable<Basket> GetAllBaskets()
        {
            throw new NotImplementedException();
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
            return entities.News_image;
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
    }
}
