using BLL.Facade;
using BLL.UnitOfWork;
using DTO;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    Email = model.Email
                });

                if (user != null && VerifyHashedPassword(user.Password, model.Password))
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
                    return PartialView("LoginSuccess");
                }
                else
                {
                    return PartialView("LoginFailed");
                }
            }
            return PartialView("LoginFailed");
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return buffer3.SequenceEqual(buffer4);
        }

        [AllowAnonymous]
        public ActionResult AuthError()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidator(PrivateKey = "6LdhDSAUAAAAAD3VI-m8aDG2KXbn1ooki0vKmUf3")]
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
                        bool isMan;
                        if (model.Sex == "Male")
                        {
                            isMan = true;
                        }
                        else if (model.Sex == "Female")
                        {
                            isMan = false;
                        }
                        else
                        {
                            return View("AuthError");
                        }
                        string hash = HashPassword(model.Password);
                        facade.UnitOfWork.getUser.AddItem(new UsersDto()
                        {
                            Email = model.Email,
                            Name = model.Firstname,
                            Surname = model.Surname,
                            Number = model.Number,
                            Password = hash,
                            RegDate = DateTime.Now,
                            RoleId = 3, 
                            IsMan = isMan
                        });

                        transact.Commit();
                        facade.UnitOfWork.SaveChanges();

                        user = facade.UnitOfWork.getUser.GetByInfo(new UsersDto()
                        {
                            Email = model.Email
                        });

                        if (user != null && VerifyHashedPassword(user.Password, model.Password))
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
                                DateTime.Now.AddMinutes(15),
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