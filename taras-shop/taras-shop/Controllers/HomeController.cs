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
                popular = facade.getPopularArticles(4),
                recommended = facade.getRecommendsArticles(3)
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
        public JsonResult GetItemsByFilter(int? typeId, string category, string sizes, int fromPrice, int toPrice, int page = 1)
        {
            int skipItems = 0;
            int amountItems = 8;
            return Json(getByFilter(typeId, category, sizes.Split(',').ToList(), fromPrice*100, toPrice*100, skipItems, amountItems, page), JsonRequestBehavior.AllowGet);
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

        SearchModels getByFilter(int? categoryTypeId, string category, List<string> sizes, int fromPrice, int toPrice, int skipItems, int amountItems, int page)
        {
            //it is very important!
            int typeId = 0;
            if (categoryTypeId != null)
            {
                typeId = categoryTypeId.Value;
            }
            
            SearchModels model = new SearchModels();

            CategoriesDto categoryDto = facade.UnitOfWork.getCategory.getCategoryByInfo(typeId, category);

            int categoryId = 0;
            if(categoryDto != null)
            {
                categoryId = categoryDto.Id;
            }

            List<int> sizeIds = new List<int>();
            if (sizes != null)
            {
                sizeIds = facade.UnitOfWork.getSizes.GetIdsBySizes(sizes);
            }

            int amount = 0;
            List<UnitDto> units;
            if (sizeIds != null && sizeIds.Count > 0)
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryId, fromPrice, toPrice, sizeIds, (page - 1) * amountItems, amountItems).ToList();
                amount = facade.UnitOfWork.getUnit.GetAmountUnit(categoryId, fromPrice, toPrice, sizeIds, (page - 1) * amountItems, amountItems);
            }
            else
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryId, fromPrice, toPrice, (page - 1) * amountItems, amountItems).ToList();
                amount = facade.UnitOfWork.getUnit.GetAmountUnit(categoryId, fromPrice, toPrice, (page - 1) * amountItems, amountItems);
            }

            List<ImagesDto> images = facade.UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();

            IEnumerable<Article> articles = facade.ConvertUnitsToArticles(units, images);

            int pages = articles.Count() / amountItems;

            model.Units = new List<Item>();

            //i have to change this method, because not all units have images
            model.Units = articles.Select(x => new Item()
            {
                Image = x.images.FirstOrDefault().Image,
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

        [HttpGet]
        public JsonResult GetItemsByCategory(int typeId, string category)
        {
            return Json(facade.getByFilter(typeId, category, 8), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string AddToBasket()
        {
            return "true";
        }

        [HttpGet]
        public async Task<JsonResult> LoadIndex()
        {
            var res = new { popular = facade.getPopularArticles(4), recommends = facade.getRecommendsArticles(4) };
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
            var res = new ItemPageModels(facade.getArticleById(id));

            res.CategoryType = facade.UnitOfWork.getCategoryType.GetById(res.category.TypeId).Type;
            
            return View(res);
        }

        public ActionResult ShoppingCart()
        {
            return View();
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