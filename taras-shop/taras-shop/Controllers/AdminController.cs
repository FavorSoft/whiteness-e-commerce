using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
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
            List<string> tmpName = new List<string>();
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {

                    Bitmap imageSave = WorkImage.WorkImage.CropImage(fileContent, 600, 400);
                    if (imageSave != null)
                    {
                        string path = Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                        Guid imageName = Guid.NewGuid();
                        
                        string fileName = path + "Units\\" + imageName + System.IO.Path.GetExtension(fileContent.FileName);
                        imageSave.Save(fileName, ImageFormat.Jpeg);
                        tmpName.Add(imageName.ToString());
                    }
                }
            }
            return Json(tmpName, JsonRequestBehavior.AllowGet);
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
            IEnumerable<string> images
            )
        {
            try {
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

                unitOfWork.Unit.AddItem(unit);
                foreach (string img in images) {
                    unitOfWork.Images.AddItem(new ImagesDto()
                    {
                        Image = img,
                        OwnerId = unit.Id
                    });
                }
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}