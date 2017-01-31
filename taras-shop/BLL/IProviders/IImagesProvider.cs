using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IImagesProvider
    {
        void AddItem(DTO.Images images);
        IEnumerable<DTO.Images> GetAll();
        DTO.Images GetById(int id);
    }
}
