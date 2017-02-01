using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UnitId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
