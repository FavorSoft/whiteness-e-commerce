using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Helpers
{
    public class BasketUnit :UnitDto
    {
        public int Amount { get; set; }
        public string Size { get; set; }
    }
}
