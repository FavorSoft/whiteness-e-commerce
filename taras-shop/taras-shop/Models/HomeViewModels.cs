using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using DTO.Helpers;

namespace taras_shop.Models
{
    public class HomeIndexViewModels
    {
        public IEnumerable<CategoriesDto> Categories { get; set; }
        public IEnumerable<CategoryTypeDto> CategoryTypes { get; set; }
        public IEnumerable<Article> Popular { get; set; }
        public IEnumerable<Article> Recommended { get; set; }
        public IEnumerable<SliderImagesDto> SliderImages { get; set; }
    }
}