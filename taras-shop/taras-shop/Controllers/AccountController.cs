using BLL.Facade;
using BLL.UnitOfWork;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using taras_shop.Controllers.Identity;
using taras_shop.Models;

namespace taras_shop.Controllers
{
    public class AccountController : BaseController
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
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UsersDto user = null;

                user = facade.UnitOfWork.getUser.GetByInfo(new UsersDto()
                {
                    Email = model.Email,
                    Password = model.Password
                });
                if (user != null)
                {
                    UserModel userModel = new UserModel();

                    userModel.Id = user.Id;
                    userModel.Email = user.Email;
                    userModel.Role = facade.UnitOfWork.getRole.GetById(user.RoleId).Role;

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string userData = serializer.Serialize(userModel);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        model.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        userData,
                        FormsAuthentication.FormsCookiePath
                        );
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
//                    (User as CustomIdentity).IsInRole()
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином не существует");
                }
            }
            return View(model);
        }
        
        [AllowAnonymous]
        public ActionResult AuthError()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterModel model)
        {
            
            if (ModelState.IsValid)
            {
                UsersDto user = null;
                user = facade.UnitOfWork.getUser.GetByInfo(new UsersDto()
                {
                    Email = model.Email
                });
                if (user == null)
                {
                    using (var transact = facade.UnitOfWork.BeginTransaction())
                    {
                        facade.UnitOfWork.getUser.AddItem(new UsersDto()
                        {
                            Email = model.Email,
                            Name = model.Firstname,
                            Surname = model.Surname,
                            Number = model.Number,
                            Password = model.Password,
                            RegDate = DateTime.Now,
                            RoleId = 3,
                            IsMan = (model.IsMan == Gender.Male)? true : false
                        });
                        transact.Commit();
                        facade.UnitOfWork.SaveChanges();

                        user = facade.UnitOfWork.getUser.GetByInfo(new UsersDto()
                        {
                            Email = model.Email,
                            Password = model.Password
                        });

                        if (user != null)
                        {
                            UserModel userModel = new UserModel();

                            userModel.Id = user.Id;
                            userModel.Email = user.Email;
                            userModel.Role = facade.UnitOfWork.getRole.GetById(user.RoleId).Role;

                            JavaScriptSerializer serializer = new JavaScriptSerializer();

                            string userData = serializer.Serialize(userModel);

                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                1,
                                model.Email,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(30),
                                false,
                                userData,
                                FormsAuthentication.FormsCookiePath
                                );
                            string encTicket = FormsAuthentication.Encrypt(ticket);

                            FormsAuthentication.SetAuthCookie(model.Email, true);
                            
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    return View("AuthError");
                }
            }
            return View("AuthError");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}