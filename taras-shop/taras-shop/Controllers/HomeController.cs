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

        public ActionResult Index()
        {
            Models.HomeIndexViewModels model = new Models.HomeIndexViewModels()
            {
                categories = facade.getBasicFunctionality().getCategory.GetAll(),
                categoryTypes = facade.getBasicFunctionality().getCategoryType.GetAll(),
                popular = facade.getBasicFunctionality().getUnit.GetPopular(4),
                recommended = facade.getBasicFunctionality().getUnit.GetRecommends()
                //popular = facade.getPopularArticles(3),
                //recommended = facade.getRecommendsArticles(4)
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult Load()
        {
            return Json(facade.getBasicFunctionality().getUnit.GetPopular(4).ToList(), JsonRequestBehavior.AllowGet);
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

        public ActionResult ItemPage()
        {
            return View();
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