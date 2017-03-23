using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class ImagesDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int OwnerId { get; set; }
    }
}
