using DTO;
using DTO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class Article
    {
        public UnitDto unit { get; set; }
        public IEnumerable<ImagesDto> images { get; set; }
        public IEnumerable<UnitInfo> sizes { get; set; }
    }
}