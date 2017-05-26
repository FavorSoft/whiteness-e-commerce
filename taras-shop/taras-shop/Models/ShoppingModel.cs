using DTO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class ShoppingModel
    {
        public IEnumerable<BasketUnit> Units { get; set; }
        public int SumPrice { get; set; }
        
    }
}