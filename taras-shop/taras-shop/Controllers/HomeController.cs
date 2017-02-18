using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.UnitOfWork;

namespace taras_shop.Controllers
{
    public class HomeController : Controller
    {
        #region PARAMETERS
        readonly IUnitOfWork unitOfWork;
        #endregion

        #region CTOR
        public HomeController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        #endregion

        public ActionResult Index()
        {
            Models.HomeIndexViewModels model = new Models.HomeIndexViewModels()
            {
                categories = unitOfWork.Category.GetAll(),
                categoryTypes = unitOfWork.CategoryType.GetAll(),
                popular = unitOfWork.Unit.GetPopular(4),
                recommended = unitOfWork.Unit.GetRecommends()
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult Load()
        {
            return Json(unitOfWork.Unit.GetPopular(4).ToList(), JsonRequestBehavior.AllowGet);
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
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}