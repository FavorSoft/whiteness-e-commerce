using BLL;
using DTO;
using BLL.IProviders;
using BLL.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace taras_shop.Controllers
{
    public class HomeController : Controller
    {
        ICategoryProvider _categoryProvider;
        public HomeController(ICategoryProvider categoryProvider)
        {
            _categoryProvider = categoryProvider;
        }
        public ActionResult Index()
        {
            
            ICategoryTypeProvider _categoryTypeProvider = new CategoryTypeProvider();
            IUnitProvider _unitProvider = new UnitProvider();
            Models.HomeIndexViewModels model = new Models.HomeIndexViewModels()
            {
                categories = _categoryProvider.GetAll(),
                categoryTypes = _categoryTypeProvider.GetAll(),
                popular = _unitProvider.GetPopular(4),
                recommended = _unitProvider.GetRecommends()
            };

            return View(model);
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

        public ActionResult Search()
        {
            return View();
        }
    }
    
}