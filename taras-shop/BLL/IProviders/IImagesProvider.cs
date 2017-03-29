using DTO;
using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface IImagesProvider: IProvider<ImagesDto>
    {
        IEnumerable<ImagesDto> GetByOwners(int[] ids);
        IEnumerable<ImagesDto> GetByOwner(int id);
    }
}
