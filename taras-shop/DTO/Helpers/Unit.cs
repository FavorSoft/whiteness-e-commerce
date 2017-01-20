using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Helpers
{
    public class Unit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public Nullable<int> Price { get; set; }
        public int Category_id { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Likes { get; set; }
        public string Description { get; set; }
    }
}
