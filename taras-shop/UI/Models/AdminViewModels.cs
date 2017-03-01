using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class AdminAddUnitViewModels
    {
        public IEnumerable<CategoryTypeDto> categoryTypes { get; set; }
        public IEnumerable<CategoriesDto> categories { get; set; }
    }
}