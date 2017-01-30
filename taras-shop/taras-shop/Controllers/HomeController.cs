using BLL;
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
        public ActionResult Index()
        {
            ICategoryProvider _provider = new CategoryProvider();
            ViewBag.Message = "";
            foreach (var i in _provider.GetAll())
            {
                ViewBag.Message += i.Category + "\n";
            }
            return View();
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
    }
}