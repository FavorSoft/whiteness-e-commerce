using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using DTO.Helpers;

namespace taras_shop.Models
{
    public class OrderingModels
    {
        public IEnumerable<BasketUnit> Units { get; set; }
        public int SumPrice { get; set; }
    }
}