using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
namespace taras_shop.Models
{
    public class HomeIndexViewModels
    {
        public IEnumerable<CategoriesDto> categories { get; set; }
        public IEnumerable<CategoryTypeDto> categoryTypes { get; set; }
        public IEnumerable<UnitDto> popular { get; set; }
        public IEnumerable<UnitDto> recommended { get; set; }
        
    }

}