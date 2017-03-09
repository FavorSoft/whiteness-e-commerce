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
using System.Threading.Tasks;
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
        public async Task<ActionResult> AddUnitPage()
        {
            Models.AdminAddUnitViewModels model = new Models.AdminAddUnitViewModels()
            {
                categories = facade.getBasicFunctionality().getCategory.GetAll(),
                categoryTypes = facade.getBasicFunctionality().getCategoryType.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Upload(
        #region uploadParameters
            List<HttpPostedFileBase> images,
            string title,
            string producer,
            int category_type,
            int category,
            Nullable<double> price,
            int amount_xs,
            int amount_s,
            int amount_m,
            int amount_l,
            int amount_xl,
            string material,
            string description
        #endregion
            )
        {
            using (var transact = facade.getBasicFunctionality().BeginTransaction())
            {
                List<string> guidImages = new List<string>();
                try
                {
                    guidImages = await UploadPhotoAsync(images);
                    var unit = new UnitDto()
                    {
                        Title = title,
                        Producer = producer,
                        CategoryId = category,
                        Price = Convert.ToInt32(price * 100),
                        Material = material,
                        Description = description,
                        Color = "default",
                        Likes = 0
                    };
                    facade.getBasicFunctionality().getUnit.AddItem(unit);
                    foreach (string img in guidImages)
                    {
                        facade.getBasicFunctionality().getImages.AddItem(new ImagesDto()
                        {
                            Image = img,
                            OwnerId = unit.Id
                        });
                    }
                    Dictionary<int, int> sizes = amountCounter(amount_xs, amount_s, amount_m, amount_l, amount_xl);
                    foreach(var i in sizes)
                    {
                        if (i.Value != null && i.Value != 0)
                        {
                            facade.getBasicFunctionality().getUnitInfo.AddItem(new UnitInfoDto()
                            {
                                UnitId = unit.Id,
                                SizeId = i.Key,
                                Amount = i.Value
                            });
                        }
                    }
                    
                    transact.Commit();
                    facade.getBasicFunctionality().SaveChanges();
                }
                catch (Exception e)
                {
                    transact.Rollback();
                    string path = Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                    string fileName = path + "Units\\";
                    for(int i = 0; i < guidImages.Count; i++)
                    {
                        guidImages[i] += System.IO.Path.GetExtension(images[i].FileName);
                    }
                    WorkImage.WorkImage.DeleteImages(fileName, guidImages);
                }
                
            }
            return RedirectToAction("AddUnitPage");
        }
        
        Dictionary<int, int> amountCounter(
            int amount_xs,
            int amount_s,
            int amount_m,
            int amount_l,
            int amount_xl)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            res.Add(1, amount_xl);
            res.Add(2, amount_l);
            res.Add(3, amount_m);
            res.Add(4, amount_s);
            res.Add(5, amount_xs);
            return res;
        }

        public async Task<List<string>> UploadPhotoAsync(List<HttpPostedFileBase> imgs)
        {
            List<string> images = new List<string>();
            foreach (var file in imgs)
            {
                if (file != null && file.ContentLength > 0)
                {

                    Bitmap imageSave = await WorkImage.WorkImage.CropImageAsync(file, 600, 400);
                    if (imageSave != null)
                    {
                        string path = Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                        Guid imageName = Guid.NewGuid();

                        string fileName = path + "Units\\" + imageName + System.IO.Path.GetExtension(file.FileName);
                        imageSave.Save(fileName, ImageFormat.Jpeg);
                        images.Add(imageName.ToString());
                    }
                }
            }
            return images;
        }

        protected override void Dispose(bool disposing)
        {
            facade.getBasicFunctionality().Dispose();
            base.Dispose(disposing);
        }
    }
}