using DTO;
using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface IUnitInfoProvider : IProvider<UnitInfoDto>
    {
        IEnumerable<UnitInfoDto> GetByOwners(int[] ids);
        IEnumerable<UnitInfoDto> GetByOwner(int id);
    }
}
