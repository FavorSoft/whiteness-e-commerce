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
        public int UnitId { get; set; }
        public string Size { get; set; }
        public DateTime WasAdded { get; set; }
        public int Amount { get; set; }
    }
}
