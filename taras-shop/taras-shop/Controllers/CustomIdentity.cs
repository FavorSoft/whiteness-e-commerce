using BLL.Facade;
using BLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace taras_shop.Controllers
{
    public class CustomIdentity : System.Security.Principal.IPrincipal
    {
        readonly Facade facade;
        
        public CustomIdentity(string username, Facade facade)
        {
            this.Identity = new GenericIdentity(username);
            this.facade = facade;
        }

        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return Identity != null && Identity.IsAuthenticated &&
                   !string.IsNullOrWhiteSpace(role) && facade.isUserInRole(Identity.Name, role);
        }

    }
}