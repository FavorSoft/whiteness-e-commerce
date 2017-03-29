using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BasketItemsDto
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int UnitInfoId { get; set; }
        public int Amount { get; set; }
    }
}
