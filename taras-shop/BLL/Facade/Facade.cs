using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BLL.Facade
{
    public class Facade
    {
        public Facade(IUnitOfWork _uow)
        {
            UnitOfWork = _uow;
        }

        private List<Article> ConvertUnitsToArticles(List<UnitDto> units, List<ImagesDto> images)
        {
            List<Article> articles = new List<Article>();
            for (int i = 0; i < units.Count; i++)
            {
                int id = units[i].Id;
                
                List<UnitInfoDto> unitsInfo = new List<UnitInfoDto>();
                foreach (var k in UnitOfWork.getUnitInfo.GetByOwner(id))
                {
                    unitsInfo.Add(k);
                }

                articles.Add(new Article()
                {
                    unit = units[i],
                    images = images.Where(x => x.OwnerId == id).ToList(),
                    category = UnitOfWork.getCategory.GetById(units[i].CategoryId),
                    sizes = UnitOfWork.getSizes.GetAll(),
                    unitsInfo = unitsInfo
                });
            }
            return articles;
        }

        private Article ConvertUnitToArticle(UnitDto unit, List<ImagesDto> images)
        {
            List<UnitInfoDto> unitsInfo = new List<UnitInfoDto>();
            foreach (var i in UnitOfWork.getUnitInfo.GetByOwner(unit.Id))
            {
                unitsInfo.Add(i);
            }
            Article article = new Article()
            {
                unit = unit,
                images = images.Where(x => x.OwnerId == unit.Id).ToList(),
                category = UnitOfWork.getCategory.GetById(unit.CategoryId),
                sizes = UnitOfWork.getSizes.GetAll(),
                unitsInfo = unitsInfo
            };

            return article;
        }

        public IEnumerable<Article> getPopularArticles(int count)
        {
            var units = UnitOfWork.getUnit.GetPopular(count);
            return ConvertUnitsToArticles(units.ToList(), UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
        }

        public object getByFilter(int categoryId, int startPrice, int endPrice, List<string> sizes, int skipItems, int amountItems)
        {
            List<int> sizeIds = new List<int>();
            sizeIds = UnitOfWork.getSizes.GetIdsBySizes(sizes);

            List<UnitDto> units = UnitOfWork.getUnit.GetByFilter(categoryId, startPrice, endPrice, sizeIds, skipItems, amountItems).ToList();

            List<ImagesDto> images = UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();

            IEnumerable<Article> articles = ConvertUnitsToArticles(units, images);

            JavaScriptSerializer s = new JavaScriptSerializer();

            int pages = UnitOfWork.getUnit.GetAmountByFilter(categoryId, startPrice, endPrice) / amountItems;

            var res = new
            {
                units = s.Serialize(articles.Select(x => x.unit).ToList()),
                images = s.Serialize(articles.Select(x => x.images).ToList()),
                sizes = s.Serialize(articles.Select(x => x.sizes).ToList()),
                unitDtos = s.Serialize(articles.Select(x => x.unitsInfo).ToList()),
                categories = s.Serialize(articles.Select(x => x.category).ToList()),
                page = (pages - skipItems) / amountItems,
                pages = pages
            };

            return res;
        }

        public object getByFilter(int typeId, string category, int amountItems)
        {
            //int categoryId = UnitOfWork.getCategory.

            //List<UnitDto> units = UnitOfWork.getUnit.GetByFilter(categoryId, amountItems).ToList();

            //List<ImagesDto> images = UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();
            //
            //IEnumerable<Article> articles = ConvertUnitsToArticles(units, images);
            //
            //JavaScriptSerializer s = new JavaScriptSerializer();
            //
            //int pages = UnitOfWork.getUnit.GetAmountByFilter(categoryId, startPrice, endPrice) / amountItems;
            //
            //var res = new
            //{
            //    units = s.Serialize(articles.Select(x => x.unit).ToList()),
            //    images = s.Serialize(articles.Select(x => x.images).ToList()),
            //    sizes = s.Serialize(articles.Select(x => x.sizes).ToList()),
            //    unitDtos = s.Serialize(articles.Select(x => x.unitsInfo).ToList()),
            //    categories = s.Serialize(articles.Select(x => x.category).ToList()),
            //    page = (pages - skipItems) / amountItems,
            //    pages = pages
            //};

            return null;
        }

        public IEnumerable<Article> getRecommendsArticles(int count)
        {
            List<Article> res = new List<Article>();
            var units = UnitOfWork.getUnit.GetPopular(count);
            res = ConvertUnitsToArticles(units.ToList(), UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
            return res;
        }

        public Article getArticleById(int id)
        {
            return ConvertUnitToArticle(UnitOfWork.getUnit.GetById(id), UnitOfWork.getImages.GetByOwner(id).ToList());
        }

        public string getUserRole(string username)
        {
            int userRole = UnitOfWork.getUser.GetByInfo(new UsersDto()
            {
                Email = username
            }).RoleId;

            return UnitOfWork.getRole.GetById(userRole).Role;
        }


        public void changeRole(int userId, string role)
        {
            int roleId = UnitOfWork.getRole.GetIdByRole(role);
            UnitOfWork.getUser.ChangeRole(userId, roleId);
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
