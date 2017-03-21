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

namespace taras_shop.Controllers
{
    public class HomeController : Controller
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
                categories = facade.getBasicFunctionality().getCategory.GetAll(),
                categoryTypes = facade.getBasicFunctionality().getCategoryType.GetAll(),
                popular = facade.getPopularArticles(4),
                recommended = facade.getRecommendsArticles(3)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> LoadSideBar()
        {
            var res = new {category_types = facade.getBasicFunctionality().getCategoryType.GetAll(), categories = facade.getBasicFunctionality().getCategory.GetAll(), sizes = facade.getBasicFunctionality().getSizes.GetAll()};
            return Json(res, JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> GetItemById(int id)
        {
            return View(facade.getArticleById(id));
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
            facade.getBasicFunctionality().Dispose();
            base.Dispose(disposing);
        }
    }
}