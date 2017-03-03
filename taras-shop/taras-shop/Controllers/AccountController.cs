using BLL.Facade;
using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using taras_shop.Models;

namespace taras_shop.Controllers
{
    public class AccountController : Controller
    {
        #region PARAMETERS
        readonly Facade facade;
        #endregion

        #region CTOR
        public AccountController(IUnitOfWork uow)
        {
            facade = new Facade(uow);
        }
        #endregion
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new Auth.LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Auth.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UsersDto user = null;

                user = facade.getBasicFunctionality().getUser.GetByInfo(new UsersDto()
                {
                    Email = model.Email,
                    Password = model.Password
                });
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином не существует");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Auth.RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UsersDto user = null;
                user = facade.getBasicFunctionality().getUser.GetByInfo(new UsersDto()
                {
                    Email = model.Email
                });
                if (user == null)
                {
                    using (var transact = facade.getBasicFunctionality().BeginTransaction())
                    {
                        facade.getBasicFunctionality().getUser.AddItem(new UsersDto()
                        {
                            Email = model.Email,
                            Name = model.Firstname,
                            Surname = model.Surname,
                            Number = model.Number,
                            Password = model.Password,
                            RegDate = DateTime.Now,
                            RoleId = 3,
                            IsMan = model.IsMan
                        });
                        transact.Commit();
                        facade.getBasicFunctionality().SaveChanges();

                        user = facade.getBasicFunctionality().getUser.GetByInfo(new UsersDto()
                        {
                            Email = model.Email,
                            Password = model.Password
                        });

                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Email, true);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}