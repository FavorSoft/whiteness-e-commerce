using BLL.UnitOfWork;
using DTO;
using DTO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static BLL.Providers.BasketProvider;

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
                return res;
            }

            using (var transact = UnitOfWork.BeginTransaction())
            {
                int? basketId = null;

                try
                {
                    basketId = UnitOfWork.getBasket.GetByOwner(userId).Id;
                }
                catch (ItemNotFoundException e)
                {
                    basketId = UnitOfWork.getBasket.AddItem(new BasketDto()
                    {
                        UserId = userId
                    });
                }
                
                UnitOfWork.getBasketItems.AddItem(new BasketItemsDto()
                {
                    Size = size,
                    Amount = 1,
                    BasketId = basketId.Value,
                    WasAdded = DateTime.Now
                });

                transact.Commit();
                res = "Товар добавлен в корзину";
            }
            return res;
        }

        public IEnumerable<BasketUnit> GetFromBasket(int id)
        {
            List<BasketUnit> res = new List<BasketUnit>();
            try
            {
                var basket = UnitOfWork.getBasket.GetByOwner(id);
                var basketItems = UnitOfWork.getBasketItems.GetByBasket(basket);
                var units = UnitOfWork.getUnit.GetByIds(basketItems.Select(x => x.UnitId).ToList());

                foreach (var i in basketItems)
                {
                    var unit = units.Where(x => x.Id == i.UnitId).FirstOrDefault();
                    res.Add(new BasketUnit()
                    {
                        Id = unit.Id,
                        AddUnitDate = i.WasAdded,
                        Amount = i.Amount,
                        CategoryId = unit.CategoryId,
                        Color = unit.Color,
                        Description = unit.Description,
                        Likes = unit.Likes,
                        Material = unit.Material,
                        OldPrice = unit.OldPrice,
                        Price = unit.Price,
                        Producer = unit.Producer,
                        Size = i.Size,
                        Title = unit.Title
                    });
                }

                return res;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException();
            }
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
