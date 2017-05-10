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

        public List<Article> ConvertUnitsToArticles(List<UnitDto> units, List<ImagesDto> images)
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

        public Article ConvertUnitToArticle(UnitDto unit, List<ImagesDto> images)
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

        public IEnumerable<Article> GetPopularArticles(int count)
        {
            var units = UnitOfWork.getUnit.GetPopular(count);
            return ConvertUnitsToArticles(units.ToList(), UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
        }

        public object GetByFilter(int categoryTypeId, string category, List<string> sizes, int startPrice, int endPrice, int skipItems, int amountItems)
        {
            int categoryId = UnitOfWork.getCategory.getCategoryByInfo(categoryTypeId, category).Id;

            List<int> sizeIds = new List<int>();
            sizeIds = UnitOfWork.getSizes.GetIdsBySizes(sizes);

            List<UnitDto> units;
            if (sizeIds != null && sizeIds.Count > 0)
            {
                units = UnitOfWork.getUnit.GetByFilter(categoryId, startPrice, endPrice, sizeIds, skipItems, amountItems).ToList();
            }
            else
            {
                units = UnitOfWork.getUnit.GetByFilter(categoryId, startPrice, endPrice, skipItems, amountItems).ToList();
            }

            List<ImagesDto> images = UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();

            IEnumerable<Article> articles = ConvertUnitsToArticles(units, images);

            JavaScriptSerializer s = new JavaScriptSerializer();

            int pages = articles.Count() / amountItems;

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

        public IEnumerable<Article> GetRecommendsArticles(int count)
        {
            List<Article> res = new List<Article>();
            var units = UnitOfWork.getUnit.GetPopular(count);
            res = ConvertUnitsToArticles(units.ToList(), UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList());
            return res;
        }

        public Article GetArticleById(int id)
        {
            return ConvertUnitToArticle(UnitOfWork.getUnit.GetById(id), UnitOfWork.getImages.GetByOwner(id).ToList());
        }

        public string GetUserRole(string username)
        {
            int userRole = UnitOfWork.getUser.GetByInfo(new UsersDto()
            {
                Email = username
            }).RoleId;

            return UnitOfWork.getRole.GetById(userRole).Role;
        }

        public void ChangeRole(int userId, string role)
        {
            int roleId = UnitOfWork.getRole.GetIdByRole(role);
            using (var transact = UnitOfWork.BeginTransaction())
            {
                UnitOfWork.getUser.ChangeRole(userId, roleId);
                UnitOfWork.getUser.SaveChanges();
                transact.Commit();
            }
        }

        public string AddItemToBasket(int unitId, string size, int userId)
        {
            string res = "";
            UnitInfoDto unitInfo = new UnitInfoDto();
            try
            {
                unitInfo = UnitOfWork.getUnitInfo.GetByIdAndSize(unitId, size);
            }
            catch (Exception)
            {
                res = "Выбранного размера нету в наличии";
            }

            using (var transact = UnitOfWork.BeginTransaction())
            {
                int? basketId = null;

                try
                {
                    basketId = UnitOfWork.getBasket.GetByOwner(userId).Id;
                }
                catch (Exception)
                {
                    basketId = UnitOfWork.getBasket.AddItem(new BasketDto()
                    {
                        UserId = userId
                    });
                }
                
                UnitOfWork.getBasketItems.AddItem(new BasketItemsDto()
                {
                    UnitInfoId = unitInfo.Id,
                    Amount = 1,
                    BasketId = basketId.Value,
                    WasAdded = DateTime.Now
                });

                transact.Commit();
                res = "Товар добавлен в корзину";
            }
            return res;
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
