using BLL.Facade;
using BLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace taras_shop.Controllers.Identity
{
    public class CustomPrincipal : ICustomPrincipal
    {
        Facade facade = new Facade(new UnitOfWork());

        public int Id { get; set; }

        public string Role { get; set; }
        
        public IIdentity Identity { get; private set; }
        
        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public bool IsInRole(string role)
        {
            return facade.UnitOfWork.getUser.;
        }
    }
}