using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class User
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
    public class AllUsersModels
    {
        public IEnumerable<User> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }    
        public int PageSize { get; set; }
        public int TotalItems { get; set; } 
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}