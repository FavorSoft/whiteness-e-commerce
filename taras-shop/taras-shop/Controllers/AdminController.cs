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
        [HttpPost]
        public String AddNewsInfo(string title, string description)
        {
            using (Entities db = new Entities())
            {
                db.News.Add(new News() { title = title, description = description, data_create = new DateTime().ToLocalTime() });
            }
            //string response = images.ToList().Count.ToString();
            return "True";
        }
        [HttpPost]
        public String AddNewsFoto()
        {
            //    using (Entities db = new Entities())
            //    {
            //        db.News.Add(new News() { title = title, description = description, data_create = new DateTime().ToLocalTime() });
            //    }
            //    //string response = images.ToList().Count.ToString();
            string count = Request.Files.Count.ToString();
            return count;
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