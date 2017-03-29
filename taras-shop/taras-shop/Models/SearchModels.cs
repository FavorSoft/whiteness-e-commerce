using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class SearchModels
    {
        public List<Item> Units { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class Item : UnitDto
    {
        public string Category { get; set; }
        public string Image { get; set; }
    }
}