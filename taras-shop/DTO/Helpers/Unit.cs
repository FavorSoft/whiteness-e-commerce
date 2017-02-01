﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UnitDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public Nullable<int> Price { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Likes { get; set; }
        public string Description { get; set; }
    }
}
