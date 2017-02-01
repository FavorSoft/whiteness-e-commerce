using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoriesDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int TypeId { get; set; }
        public string CategoryImg { get; set; }
        public string Description { get; set; }
    }
}
