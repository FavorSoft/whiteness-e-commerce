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
        #region PARAMETERS
        readonly IBasketItemsProvider _basketItems;
        readonly IBasketProvider _basket;
        readonly ICategoryProvider _category;
        readonly ICategoryTypeProvider _categoryType;
        readonly IImagesProvider _images;
        readonly INewsImagesProvider _newsImages;
        readonly INewsProvider _news;
        readonly IOrderItemsProvider _orderItems;
        readonly IOrderProvider _order;
        readonly IRoleProvider _role;
        readonly IUnitProvider _unit;
        readonly IUserProvider _user;
        #endregion

        #region CTOR
        public HomeController(
            IBasketItemsProvider basketItems,
            IBasketProvider basket,
            ICategoryProvider category,
            ICategoryTypeProvider categoryType,
            IImagesProvider images,
            INewsImagesProvider newsImages,
            INewsProvider news,
            IOrderItemsProvider orderItems,
            IOrderProvider order,
            IRoleProvider role,
            IUnitProvider unit,
            IUserProvider user
            )
        {
            // Dependency Injection
            _basketItems = basketItems;
            _basket = basket;
            _category = category;
            _categoryType = categoryType;
            _images = images;
            _newsImages = newsImages;
            _news = news;
            _orderItems = orderItems;
            _order = order;
            _role = role;
            _unit = unit;
            _user = user;
        }
        #endregion

        public ActionResult Index()
        {
            Models.HomeIndexViewModels model = new Models.HomeIndexViewModels()
            {
                categories = _category.GetAll(),
                categoryTypes = _categoryType.GetAll(),
                popular = _unit.GetPopular(4),
                recommended = _unit.GetRecommends()
            };

            return View(model);
        }

        [HttpGet]
        public List<UnitDto> Load()
        {
            return _unit.GetPopular(4).ToList();
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