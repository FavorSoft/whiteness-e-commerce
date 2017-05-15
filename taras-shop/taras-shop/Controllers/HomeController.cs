using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.UnitOfWork;
using taras_shop.Models;
using BLL.Facade;
using BLL.IFacade;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using taras_shop.Controllers.Identity;

namespace taras_shop.Controllers
{
    public class HomeController : BaseController
    {


        #region PARAMETERS
        readonly Facade facade;
        #endregion

        #region CTOR
        public HomeController(IUnitOfWork uow)
        {
            facade = new Facade(uow);
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            Models.HomeIndexViewModels model = new Models.HomeIndexViewModels()
            {
                categories = facade.UnitOfWork.getCategory.GetAll(),
                categoryTypes = facade.UnitOfWork.getCategoryType.GetAll(),
                popular = facade.GetPopularArticles(4),
                recommended = facade.GetRecommendsArticles(3)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> LoadSideBar()
        {
            var res = new
            {
                category_types = facade.UnitOfWork.getCategoryType.GetAll(),
                categories = facade.UnitOfWork.getCategory.GetAll(),
                sizes = facade.UnitOfWork.getSizes.GetAll()
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult ItemOnBasket(int personId)
        {
            if (!String.IsNullOrWhiteSpace(User.Identity.Name))
            {
                return View("NoAuth");
            }

            return View("NullItemOnBasket");
        }


        #region GetItemsByFilter
        [HttpGet]
        public JsonResult GetItemsByFilter(int? typeId, string category, string sizes, int fromPrice, int toPrice, int page = 1)
        {
            int amountItems = 8;

            List<int> categories = ChoiceCategory(typeId, category);

            List<int> sizeIds = ChoiceSizes(sizes.Split(',').ToList());

            SearchModels model = GetArticles(categories, sizeIds, fromPrice*100, toPrice*100, page, amountItems);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private List<int> ChoiceCategory(int? categoryTypeId, string category)
        {
            List<int> res = new List<int>();

            int typeId = 0;
            if (categoryTypeId != null)
            {
                typeId = categoryTypeId.Value;
            }

            List<CategoriesDto> categoryDtos = facade.UnitOfWork.getCategory.getCategoryByInfo(typeId, category);

            foreach (var i in categoryDtos)
            {
                res.Add(i.Id);
            }

            return res;
        }

        private List<int> ChoiceSizes(List<string> sizes)
        {
            List<int> res = new List<int>();

            if (sizes != null)
            {
                res = facade.UnitOfWork.getSizes.GetIdsBySizes(sizes);
            }

            return res;
        }
        
        private SearchModels GetArticles(List<int> categoryIds, List<int> sizeIds, int fromPrice, int toPrice, int page, int amountItems)
        {
            SearchModels model = new SearchModels();
            List<Article> res = new List<Article>();

            int amount = 0;
            List<UnitDto> units;
            if (sizeIds != null && sizeIds.Count > 0)
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryIds, fromPrice, toPrice, sizeIds, (page - 1) * amountItems, amountItems).ToList();
                amount = facade.UnitOfWork.getUnit.GetAmountUnit(categoryIds, fromPrice, toPrice, sizeIds, (page - 1) * amountItems, amountItems);
            }
            else
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryIds, fromPrice, toPrice, (page - 1) * amountItems, amountItems).ToList();
                amount = facade.UnitOfWork.getUnit.GetAmountUnit(categoryIds, fromPrice, toPrice, (page - 1) * amountItems, amountItems);
            }

            List<ImagesDto> images = facade.UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();

            res = facade.ConvertUnitsToArticles(units, images);

            model.Units = new List<Item>();

            model.Units = res.Select(x => new Item()
            {
                Image = (x.images.FirstOrDefault().Image ?? "womant.jpg"),
                AddUnitDate = x.unit.AddUnitDate,
                CategoryId = x.unit.CategoryId,
                Color = x.unit.Color,
                Description = x.unit.Description,
                Id = x.unit.Id,
                Likes = x.unit.Likes,
                Material = x.unit.Material,
                OldPrice = x.unit.OldPrice,
                Price = x.unit.Price,
                Producer = x.unit.Producer,
                Title = x.unit.Title,
                Category = x.category.Category

            }).ToList();
            
            model.PageInfo = new PageInfo();
            model.PageInfo.PageNumber = page;
            model.PageInfo.PageSize = 8;
            model.PageInfo.TotalItems = amount;
            
            return model;
        }
        #endregion

        //, string xs_option2, string s_option2, string m_option2, string l_option2, string xl_option2
        [HttpPost]
        [CustomAuthorizeAttribute]
        public string AddToBasket(int Id, string size)
        {
            string res = facade.AddItemToBasket(Id, size, User.Id);
            
            return res;
        }

        [HttpGet]
        public async Task<JsonResult> LoadIndex()
        {
            var res = new { popular = facade.GetPopularArticles(4), recommends = facade.GetRecommendsArticles(4) };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Ordering()
        {
            return View();
        }

        public ActionResult Page404()
        {
            return View();
        }

        public async Task<ActionResult> ItemPage(int id)
        {
            var res = new ItemPageModels(facade.GetArticleById(id));

            res.CategoryType = facade.UnitOfWork.getCategoryType.GetById(res.category.TypeId).Type;
            
            return View(res);
        }

        public ActionResult ShoppingCart()
        {
            string res = "false";
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    res = "true";
                }
            }
            catch (Exception)
            {
                
            }
            return View(res as object);
        }
        [HttpGet]
        public ActionResult GetItemsFromBasket()
        {
            JsonResult res;
            try{
                var items = facade.GetFromBasket(User.Id);
                res = Json(items, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                res = Json("Ваша корзина пустая", JsonRequestBehavior.AllowGet);
            }
            return res;
        }

        public ActionResult Search()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            facade.UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}