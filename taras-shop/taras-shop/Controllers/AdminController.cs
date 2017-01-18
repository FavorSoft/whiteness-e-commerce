using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taras_shop;

namespace taras_shop.Controllers
{
    
    public class AdminController : Controller
    {

        public ActionResult AddNews()
        {
            return View();
        }
        public ActionResult AddNews(string title, string description, IEnumerable<HttpPostedFileBase> images)
        {
            Boolean query = false;
            using (Entities db = new Entities())
            {
                db.News.Add(new News() { title = title, description = description, data_create = new DateTime().ToLocalTime() });
            }

            return PartialView("");
        }
        public ActionResult AddContent()
        {
            return View();

        }
        public ActionResult AddSale()
        {
            return View();
        }
    }
}