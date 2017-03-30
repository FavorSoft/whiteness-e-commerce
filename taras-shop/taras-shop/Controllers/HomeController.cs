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
        public JsonResult GetItemsByFilter(int typeId, string category, List<string> sizes, int fromPrice, int toPrice)
        {
            return Json(getByFilter(typeId, category, sizes, 0, 100000, 0, 8), JsonRequestBehavior.AllowGet);
        }

        //public ViewResult ItemOnBasket(int personId)
        //{
        //    //var unit = _repo
        //
        //    //var model = new Models.ItemOnBasket();
        //
        //    //model.
        //
        //    //return View(model);
        //}

        SearchModels getByFilter(int categoryTypeId, string category, List<string> sizes, int startPrice, int endPrice, int skipItems, int amountItems)
        {
            SearchModels model = new SearchModels();

            int categoryId = facade.UnitOfWork.getCategory.getCategoryByInfo(categoryTypeId, category).Id;

            List<int> sizeIds = new List<int>();
            if (sizes != null)
            {
                sizeIds = facade.UnitOfWork.getSizes.GetIdsBySizes(sizes);
            }

            List<UnitDto> units;
            if (sizeIds != null && sizeIds.Count > 0)
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryId, startPrice, endPrice, sizeIds, skipItems, amountItems).ToList();
            }
            else
            {
                units = facade.UnitOfWork.getUnit.GetByFilter(categoryId, startPrice, endPrice, skipItems, amountItems).ToList();
            }

            List<ImagesDto> images = facade.UnitOfWork.getImages.GetByOwners(units.Select(x => x.Id).ToArray()).ToList();

            IEnumerable<Article> articles = facade.ConvertUnitsToArticles(units, images);

            int pages = articles.Count() / amountItems;

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

            model.Units.AddRange(model.Units);
            model.Units.AddRange(model.Units);


            model.PageInfo = new PageInfo();
            model.PageInfo.PageNumber = 1;
            model.PageInfo.PageSize = 8;
            model.PageInfo.TotalItems = model.Units.Count();
            
            return model;
        }

        [HttpGet]
        public JsonResult GetItemsByCategory(int typeId, string category)
        {
            return Json(facade.getByFilter(typeId, category, 8), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToBasket()
        {

            return View();
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