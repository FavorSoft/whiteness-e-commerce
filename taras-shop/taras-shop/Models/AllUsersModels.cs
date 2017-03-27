using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class AllUsersModels
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public System.DateTime RegDate { get; set; }
    }
}