using BLL.UnitOfWork;
using DTO;
using DTO.Exceptions;
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
                res = "Выбранного размера нету в наличиию";
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
                    UnitOfWork.getBasket.AddItem(new BasketDto()
                    {
                        UserId = userId
                    });
                    transact.Commit();
                    UnitOfWork.SaveChanges();
                    basketId = UnitOfWork.getBasket.GetByOwner(userId).Id;
                }
                catch (Exception e)
                {
                    res = "Что-то пошло не так.";
                }

                if (UnitOfWork.getBasketItems.GetByInfo(unitId, size, basketId.Value).Count() == 0)
                {
                    var basketItem = new BasketItemsDto()
                    {
                        Size = size,
                        Amount = 1,
                        BasketId = basketId.Value,
                        UnitId = unitId,
                        WasAdded = DateTime.Now
                    };
                    UnitOfWork.getBasketItems.AddItem(basketItem);
                    transact.Commit();

                    UnitOfWork.SaveChanges();
                    res = "Товар добавлен в корзину.";
                }
                else
                {
                    res = "Такой товар уже добавлен. Смотрите в корзине.";
                }
            }
            return res;
        }

        public IEnumerable<BasketUnit> GetFromBasket(int id)
        {
            List<BasketUnit> res = new List<BasketUnit>();
            try
            {
                var basket = UnitOfWork.getBasket.GetByOwner(id);
                var basketItems = UnitOfWork.getBasketItems.GetByBasket(basket).ToList();
                var units = UnitOfWork.getUnit.GetByIds(basketItems.Select(x => x.UnitId).ToList());
                var unitInfoes = UnitOfWork.getUnitInfo.GetByOwners(units.Select(x => x.Id).ToArray());

                foreach (var i in basketItems)
                {
                    var unit = units.Where(x => x.Id == i.UnitId).FirstOrDefault();
                    var unitInfoesToCurrentItem = unitInfoes.Where(x => x.UnitId == unit.Id);
                    List<string> size = new List<string>();
                    size.Add(i.Size);
                    var sizeId = UnitOfWork.getSizes.GetIdsBySizes(size);

                    List<ImagesDto> images = UnitOfWork.getImages.GetByOwner(i.UnitId).ToList();

                    int amountFromItemFromDB = unitInfoesToCurrentItem.Where(x => x.SizeId == sizeId.FirstOrDefault()).FirstOrDefault().Amount;
                    int amountFromBasketItems = i.Amount;

                    res.Add(new BasketUnit()
                    {
                        Id = unit.Id,
                        AddUnitDate = i.WasAdded,
                        AmountOnBasket = amountFromBasketItems,
                        AmountOnStorage = amountFromItemFromDB,
                        CategoryId = unit.CategoryId,
                        Color = unit.Color,
                        Description = unit.Description,
                        Likes = unit.Likes,
                        Material = unit.Material,
                        OldPrice = unit.OldPrice,
                        Price = unit.Price,
                        Producer = unit.Producer,
                        Size = i.Size,
                        Title = unit.Title,
                        Image = images.FirstOrDefault()
                    });
                }

                return res;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<BasketUnit> GetFromBasket(List<ItemInLocalStorage> items)
        {
            List<BasketUnit> res = new List<BasketUnit>();
            try
            {
                List<UnitDto> units = UnitOfWork.getUnit.GetByIds(items.Select(x => x.Id).ToList()).ToList();
                List<UnitInfoDto> unitsInfo = UnitOfWork.getUnitInfo.GetByOwners(items.Select(x => x.Id).ToArray()).ToList();
                List<SizesDto> sizes = UnitOfWork.getSizes.GetAll().ToList();
                foreach (var i in items)
                {
                    int sizeId = sizes.Where(x => x.Size == i.Size).Select(x => x.Id).FirstOrDefault();
                    UnitDto unit = units.Where(x => x.Id == i.Id).FirstOrDefault();
                    int storageAmount = 0;
                    try
                    {
                        UnitInfoDto unitInfo = unitsInfo.Where(x => x.UnitId == i.Id && x.SizeId == sizeId).FirstOrDefault();
                        storageAmount = unitInfo.Amount;
                    }
                    catch (NullReferenceException e)
                    {
                    }
                    res.Add(new BasketUnit()
                    {
                        Id = unit.Id,
                        Title = unit.Title,
                        Size = i.Size,
                        AddUnitDate = unit.AddUnitDate,
                        AmountOnBasket = i.Amount,
                        AmountOnStorage = storageAmount,
                        CategoryId = unit.CategoryId,
                        Color = unit.Color,
                        Description = unit.Description,
                        Image = UnitOfWork.getImages.GetByOwner(unit.Id).FirstOrDefault(),
                        Likes = unit.Likes,
                        Material = unit.Material,
                        OldPrice = unit.OldPrice,
                        Price = unit.Price,
                        Producer = unit.Producer
                    });
                }

                return res;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException();
            }
        }

        public void DeleteFromBasket(int unitId, string Size, int userId)
        {
            int baskedId = UnitOfWork.getBasket.GetByOwner(unitId).Id;
            UnitOfWork.getBasketItems.DeleteByInfo(unitId, Size, baskedId);
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
