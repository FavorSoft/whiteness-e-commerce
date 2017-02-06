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
        public JsonResult UploadPhoto()
        {
            foreach(string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    Bitmap imageSave = WorkImage.CreateImage(model.UploadImage, 600, 400);
                    if (imageSave != null)
                    {
                        string path = Server.MapPath(ConfigurationManager.AppSettings["ImageProductPath"]);
                        Guid imageName = Guid.NewGuid();
                        string fileName = path + imageName + System.IO.Path.GetExtension(model.UploadImage.FileName);
                        imageSave.Save(fileName, ImageFormat.Jpeg);
                    }
                }
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    
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
            string description,
            IEnumerable<object> images
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
            
            //unitOfWork.Unit.AddItem(unit);
            
            return Json(unit, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}