using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class ItemOnBasket : UnitDto
    {
        public ItemOnBasket(UnitDto unit)
        {
            this.AddUnitDate = unit.AddUnitDate;
            this.CategoryId = unit.CategoryId;
            this.Color = unit.Color;
            this.Description = unit.Description;
            this.Id = unit.Id;
            this.Likes = unit.Likes;
            this.Material = unit.Material;
            this.OldPrice = unit.OldPrice;
            this.Price = unit.Price;
            this.Producer = unit.Producer;
        }
        public string Image { get; set; }
        public List<UnitInfoDto> UnitsInfo { get; set; }
        public List<SizesDto> Sizes { get; set; }
    }
}