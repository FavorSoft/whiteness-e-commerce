using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface ISizesProvider:IProvider<SizesDto>
    {
        List<int> GetIdsBySizes(List<string> sizes);
    }
}
