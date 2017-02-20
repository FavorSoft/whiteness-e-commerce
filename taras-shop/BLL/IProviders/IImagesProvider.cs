using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IImagesProvider: IProvider<ImagesDto>
    {
        IEnumerable<ImagesDto> GetByOwners(int[] ids);
        IEnumerable<ImagesDto> GetByOwner(int id);
    }
}
