using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class UnitDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> OldPrice { get; set; }
        public int CategoryId { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Likes { get; set; }
        public DateTime AddUnitDate { get; set; }
        public string Description { get; set; }
    }
}
