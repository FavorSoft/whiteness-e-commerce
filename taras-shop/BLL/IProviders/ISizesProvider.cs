using DTO;
using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface ISizesProvider:IProvider<SizesDto>
    {
        List<int> GetIdsBySizes(List<string> sizes);
    }
}
