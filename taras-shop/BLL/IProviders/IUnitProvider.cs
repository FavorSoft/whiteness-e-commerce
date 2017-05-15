using DTO;
using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface IUnitProvider : IProvider<UnitDto>
    {
        IEnumerable<UnitDto> GetPopular(int i);
        IEnumerable<UnitDto> GetRecommends();
        IEnumerable<UnitDto> GetSomeUnits(int start, int amount);
        IEnumerable<UnitDto> GetByFilter(int categoryId, int startPrice, int endPrice, List<int> sizesId, int skipItems, int amount);
        IEnumerable<UnitDto> GetByIds(List<int> ids);
        IEnumerable<UnitDto> GetByFilter(int categoryId, int startPrice, int endPrice, int skipItems, int amount);
        int GetAmountUnit(int categoryId, int startPrice, int endPrice, int skipItems, int amount);
        int GetAmountUnit(int categoryId, int startPrice, int endPrice, List<int> sizeIds, int skipItems, int amount);
    }
}
