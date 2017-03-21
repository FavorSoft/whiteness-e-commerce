using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Controllers.Identity
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}