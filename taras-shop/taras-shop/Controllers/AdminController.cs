using BLL.Facade;
using BLL.IFacade;
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
        readonly Facade facade;
        #endregion

        #region CTOR
        public AdminController(IUnitOfWork uow)
        {
            facade = new Facade(uow);
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
                categories = facade.getBasicFunctionality().getCategory.GetAll(),
                categoryTypes = facade.getBasicFunctionality().getCategoryType.GetAll()
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
            string categoryType,
            string category,
            string price,
            string amount,
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
                    CategoryId = Int32.Parse(category),
                    Price = Convert.ToInt32(Int32.Parse(price) * 100),
                    Material = material,
                    Description = description,
                    Color = "default",
                    Likes = 0
                };
                facade.getBasicFunctionality().getCategory.AddItem(new CategoriesDto()
                {
                    Category = "abc",
                    CategoryImg = "abc",
                    Description = "test",
                    TypeId = 1
                });
                facade.getBasicFunctionality().getUnit.AddItem(unit);
                foreach (string img in images) {
                    facade.getBasicFunctionality().getImages.AddItem(new ImagesDto()
                    {
                        Image = img,
                        OwnerId = unit.Id
                    });
                }
                facade.getBasicFunctionality().Commit();

            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            facade.getBasicFunctionality().Dispose();
            base.Dispose(disposing);
        }
    }
}