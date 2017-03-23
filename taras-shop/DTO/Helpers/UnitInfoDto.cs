using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class UnitInfoDto
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int UnitId { get; set; }
        public int Amount { get; set; }
    }
}
