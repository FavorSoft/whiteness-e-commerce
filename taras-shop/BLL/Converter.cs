using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Helpers;
namespace BLL
{
    public static class Converter
    {
        public static DTO.Helpers.Basket SqlBasketToDTOBasket(DAL.Basket basket)
        {
            return new DTO.Helpers.Basket()
            {
                Id = basket.id,
                Amount = basket.amount,
                Unit_id = basket.unit_id,
                User_id = basket.user_id
            };
        }
        public static DTO.Helpers.Categories SqlCategoriesToDTOCategories(DAL.Categories categories)
        {
            return new DTO.Helpers.Categories()
            {
                Id = categories.id,
                Category = categories.category,
                Type = categories.type,
                Description = categories.description
            };
        }
        public static DTO.Helpers.News SqlNewsToDTONews(DAL.News news)
        {
            return new DTO.Helpers.News()
            {
                Id = news.id,
                Title = news.title,
                Date_create = news.data_create,
                //Publisher_id = news.
                Description = news.description
            };
        }
        public static DTO.Helpers.Images SqlImagesToDTOImages(DAL.Images images)
        {
            return new DTO.Helpers.Images()
            {
                Id = images.id,
                Image = images.image,
                Owner_id = images.owner_id
            };
        }
        public static DTO.Helpers.News_images SqlNews_imagesToDTONews_images(DAL.News_image news_image)
        {
            return new DTO.Helpers.News_images()
            {
                Id = news_image.id,
                Image = news_image.image,
                Owner_id = news_image.owner_id
            };
        }
        public static DTO.Helpers.Roles SqlRolesToDTORoles(DAL.Roles roles)
        {
            return new DTO.Helpers.Roles()
            {
                Id = roles.id,
                Role = roles.role
            };
        }
        public static DTO.Helpers.Unit SqlUnitToDTOUnit(DAL.Unit unit)
        {
            return new DTO.Helpers.Unit()
            {
                Id = unit.id,
                Amount = unit.amount,
                Category_id = unit.category_id,
                Color = unit.color,
                Description = unit.description,
                Likes = unit.likes,
                Material = unit.material,
                Price = unit.price,
                Producer = unit.Producer,
                Size = unit.size,
                Title = unit.title
            };
        }
        public static DTO.Helpers.Users SqlUsersToDTOUsers(DAL.Users users)
        {
            return new DTO.Helpers.Users()
            {
                Id = users.id,
                Email = users.email,
                Name = users.name,
                Surname = users.surname,
                Number = users.number,
                Password = users.password,
                Reg_date = users.reg_date,
                Role_id = users.role_id
            };
        }
    }
}
