using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUnitInfoProvider : IProvider<UnitInfoDto>
    {
        IEnumerable<UnitInfoDto> GetByOwners(int[] ids);
        IEnumerable<UnitInfoDto> GetByOwner(int id);
    }
}
