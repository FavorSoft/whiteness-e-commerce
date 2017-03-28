using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class SearchModels
    {
        public List<ArticlesModel> Articles { get; set; }
        public List<ImagesDto> Images { get; set; }
        public List<SizesDto> SIzes { get; set; }
        public List<UnitInfoDto> UnitsInfo { get; set; }
        public List<CategoriesDto> Categories { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
    public class ArticlesModel : Article
    {
        //public string category { get; set; }
    }
}