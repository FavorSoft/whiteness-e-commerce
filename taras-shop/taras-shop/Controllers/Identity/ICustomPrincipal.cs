using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace taras_shop.Controllers.Identity
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Role { get; set; }
    }
}
