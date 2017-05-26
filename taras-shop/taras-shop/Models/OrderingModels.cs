using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using DTO.Helpers;

namespace taras_shop.Models
{
    public class OrderingDataModel
    {
        public List<ItemInfo> Items { get; set; }
        public UserData UserData { get; set; }
    }
    public class ItemInfo
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int Amount { get; set; }
    }
    public class OrderingModels
    {
        public IEnumerable<BasketUnit> Units { get; set; }
        public int SumPrice { get; set; }
        public UserData UserData { get; set; }
    }
    public class UserData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}