using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IImagesProvider
    {
        void AddItem(DTO.ImagesDto images);
        IEnumerable<DTO.ImagesDto> GetAll();
        DTO.ImagesDto GetById(int id);
    }
}
