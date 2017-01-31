using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
namespace taras_shop.Models
{
    public class HomeIndexViewModels
    {
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<CategoryType> categoryTypes { get; set; }
        public IEnumerable<Unit> popular { get; set; }
        public IEnumerable<Unit> recommended { get; set; }
    }
}