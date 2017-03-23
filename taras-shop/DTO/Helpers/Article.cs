using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    [Serializable]
    public class Article
    {
        public UnitDto unit { get; set; }
        public CategoriesDto category { get; set; }
        public IEnumerable<ImagesDto> images { get; set; }
        public IDictionary<SizesDto, UnitInfoDto> sizes { get; set; }
    }
}