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
    public class ArticlesModel
    {
        public Item unit { get; set; }
        public CategoriesDto category { get; set; }
        public IEnumerable<ImagesDto> images { get; set; }
        public IEnumerable<SizesDto> sizes { get; set; }
        public IEnumerable<UnitInfoDto> unitsInfo { get; set; }
    }
    public class Item : UnitDto
    {
        public string Category { get; set; }
    }
    
}