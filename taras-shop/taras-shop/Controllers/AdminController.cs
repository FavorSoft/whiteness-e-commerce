using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace taras_shop.Controllers
{
    public class AdminController : Controller
    {
        #region PARAMETERS
        readonly IUnitOfWork unitOfWork;
        #endregion

        #region CTOR
        public AdminController(IUnitOfWork uow)
        {
            // Dependency Injection
            unitOfWork = uow;
        }
        #endregion

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //[ValidateAntiForgeryToken]
        public ActionResult AddUnitPage()
        {
            Models.AdminAddUnitViewModels model = new Models.AdminAddUnitViewModels()
            {
                categories = unitOfWork.Category.GetAll(),
                categoryTypes = unitOfWork.CategoryType.GetAll()
            };

            return View(model);
        }

        /*
         title: title,
         producer: producer,
         categoryType: categoryType,
         category: category,
         price: price,
         amount: amount,
         size: size,
         material: material,
         description: description
         */
        [HttpPost]
        public JsonResult AddUnit(
            string title,
            string producer,
            int categoryType,
            int category,
            float price,
            int amount,
            string size,
            string material,
            string description
            )
        {
            var unit = new UnitDto()
            {
                Title = title,
                Producer = producer,
                CategoryId = category,
                Price = Convert.ToInt32(price * 100),
                Amount = amount,
                Size = size,
                Material = material,
                Description = description
            };
            return Json(unit, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}