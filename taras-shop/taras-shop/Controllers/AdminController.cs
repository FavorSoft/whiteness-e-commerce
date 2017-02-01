﻿using BLL.IProviders;
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
        public AdminController(
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

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUnit()
        {
            Models.AdminAddUnitViewModels model = new Models.AdminAddUnitViewModels()
            {
                categories = _category.GetAll(),
                categoryTypes = _categoryType.GetAll()
            };
            return View(model);
        }

    }
}