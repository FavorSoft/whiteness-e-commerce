using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Helpers
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date_create { get; set; }
        public string Description { get; set; }
        public int Publisher_id { get; set; }
    }
}
