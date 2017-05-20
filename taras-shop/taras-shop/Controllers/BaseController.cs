using BLL.Facade;
using BLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taras_shop.Controllers.Identity;

namespace taras_shop.Controllers
{
    public class BaseController : Controller
    {
        protected readonly Facade facade;

        public BaseController(IUnitOfWork uow)
        {
            facade = new Facade(uow);
        }

        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}