using BLL.Facade;
using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using taras_shop.Controllers.Identity;


namespace taras_shop.Controllers
{
    public class AdminController : BaseController
    {
        public enum ImageType { Slider = 0, Item };
        public AdminController(IUnitOfWork uow) : base(uow) { }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public async Task<ActionResult> AddUnitPage()
        {
            Models.AdminAddUnitViewModels model = new Models.AdminAddUnitViewModels()
            {
                categories = facade.UnitOfWork.getCategory.GetAll(),
                categoryTypes = facade.UnitOfWork.getCategoryType.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
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
            using (var transact = facade.UnitOfWork.BeginTransaction())
            {
                List<string> guidImages = new List<string>();
                try
                {
                    guidImages = await UploadPhotoAsync(images, ImageType.Item);
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
                    facade.UnitOfWork.getUnit.AddItem(unit);
                    foreach (string img in guidImages)
                    {
                        facade.UnitOfWork.getImages.AddItem(new ImagesDto()
                        {
                            Image = String.Format("{0}.jpg",img),
                            OwnerId = unit.Id
                        });
                    }
                    Dictionary<int, int> sizes = amountCounter(amount_xs, amount_s, amount_m, amount_l, amount_xl);
                    foreach (var i in sizes)
                    {
                        if (!i.Value.Equals(null) && i.Value != 0)
                        {
                            facade.UnitOfWork.getUnitInfo.AddItem(new UnitInfoDto()
                            {
                                UnitId = unit.Id,
                                SizeId = i.Key,
                                Amount = i.Value
                            });
                        }
                    }

                    transact.Commit();
                    facade.UnitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    transact.Rollback();
                    string path = Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                    string date = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                    string fileName = path + "Units\\" + date + "\\";
                    for (int i = 0; i < guidImages.Count; i++)
                    {
                        guidImages[i] += Path.GetExtension(images[i].FileName);
                    }
                    WorkImage.WorkImage.DeleteImages(fileName, guidImages);
                }

            }
            return RedirectToAction("AddUnitPage");

        }

        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public ActionResult AllUsers(int page = 1)
        {
            return View("AllUsers", GetUsersModels(page));
        }

        public Models.AllUsersModels GetUsersModels(int page)
        {
            int pageSize = 30;
            var model = new Models.AllUsersModels();
            
            model.Users = facade.UnitOfWork.getUser.GetAll((page - 1) * pageSize, pageSize).Select(x => new Models.User()
            {
                Email = x.Email,
                Gender = (x.IsMan) ? "man" : "woman",
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                RegDate = x.RegDate,
                Role = (x.RoleId == 3) ? "User" : (x.RoleId == 2) ? "Moderator" : (x.RoleId == 1) ? "Admin" : (x.RoleId == 4) ? "Banned" : "Undefined",
                Surname = x.Surname
            }).ToList();


            model.PageInfo = new Models.PageInfo();
            model.PageInfo.PageNumber = page;
            model.PageInfo.PageSize = pageSize;
            model.PageInfo.TotalItems = facade.UnitOfWork.getUser.GetAmountUsers();


            return model;
        }

        public ActionResult DeleteUnit()
        {
            return Redirect("Index");
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

        public async Task<List<string>> UploadPhotoAsync(List<HttpPostedFileBase> imgs, ImageType t)
        {

            List<string> images = new List<string>();
            foreach (var file in imgs)
            {
                if (file != null && file.ContentLength > 0)
                {
                    switch (t)
                    {
                        case ImageType.Item:
                            Bitmap imageSave = await WorkImage.WorkImage.CropImageAsync(file, 600, 400);
                            if (imageSave != null)
                            {
                                string path = Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                                Guid imageName = Guid.NewGuid();
                                
                                string date = DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

                                if (!Directory.Exists(path + "Units\\" + date)){
                                    Directory.CreateDirectory(path + date);
                                }
                            
                                string fileName = path + "Units\\" + date + "\\" + imageName + System.IO.Path.GetExtension(file.FileName);
                                imageSave.Save(fileName, ImageFormat.Jpeg);
                                images.Add(date + "/" + imageName.ToString());
                            }
                            break;
                        case ImageType.Slider:
                            Bitmap sliderImageSave = WorkImage.WorkImage.MakeBitmap(file);
                            if (sliderImageSave != null)
                            {
                                string path = Server.MapPath(ConfigurationManager.AppSettings["SliderImagesFolder"]);
                                Guid imageName = Guid.NewGuid();

                                string fileName = path + imageName + System.IO.Path.GetExtension(file.FileName);
                                sliderImageSave.Save(fileName, ImageFormat.Jpeg);
                                images.Add(imageName.ToString());
                            }
                            break;
                    }
                }
            }
            return images;
        }

        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public ActionResult BanUser(int id)
        {
            facade.ChangeRole(id, "Banned");
            return View("AllUsers", GetUsersModels(1));
        }

        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public ActionResult SetAsAdmin(int id)
        {
            facade.ChangeRole(id, "Admin");
            return View("AllUsers", GetUsersModels(1));
        }

        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public ActionResult SetAsUser(int id)
        {
            facade.ChangeRole(id, "User");
            return View("AllUsers", GetUsersModels(1));
        }

        [ValidateAntiForgeryToken]
        [CustomAuthorizeAttribute(Roles = "Admin, Moderator")]
        public ActionResult SetAsModerator(int id)
        {
            facade.ChangeRole(id, "Moderator");
            return View("AllUsers", GetUsersModels(1));
        }

        [CustomAuthorize(Roles = "Admin, Moderator")]
        public ActionResult ItemPage(int id)
        {
            var res = new Models.ItemPageModels(facade.GetArticleById(id));

            res.CategoryType = facade.UnitOfWork.getCategoryType.GetById(res.category.TypeId).Type;

            return View(res);
        }
        
        [CustomAuthorize(Roles = "Admin, Moderator")]
        public ActionResult SliderImages()
        {
            var res = facade.UnitOfWork.getSliderImages.GetAll();
            return View(res);
        }

        [CustomAuthorize(Roles = "Admin, Moderator")]
        public ActionResult DeleteSliderImage(int id)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["SliderImagesFolder"]);
            facade.DeleteSliderImage(path, id);
            return RedirectToAction("SliderImages");
        }

        [CustomAuthorize(Roles = "Admin, Moderator")]
        public ActionResult AddSliderImage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin, Moderator")]
        public async Task<ActionResult> AddSliderImageAsync(List<HttpPostedFileBase> image)
        {
            List<string> names = new List<string>();
            using (var transact = facade.UnitOfWork.BeginTransaction())
            {
                try
                {
                    names = await UploadPhotoAsync(image, ImageType.Slider);
                    facade.AddSliderImage(names);
                    facade.UnitOfWork.SaveChanges();
                    transact.Commit();
                }
                catch (Exception)
                {
                    string path = Server.MapPath(ConfigurationManager.AppSettings["SliderImagesFolder"]);

                    WorkImage.WorkImage.DeleteImages(path, names);
                    transact.Rollback();
                }
            }
            

            return View("AddSliderImage");

        }

        protected override void Dispose(bool disposing)
        {
            facade.UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}