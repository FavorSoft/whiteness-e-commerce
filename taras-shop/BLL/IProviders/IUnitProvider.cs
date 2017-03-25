using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUnitProvider : IProvider<UnitDto>
    {
        IEnumerable<UnitDto> GetPopular(int i);
        IEnumerable<UnitDto> GetRecommends();
        IEnumerable<UnitDto> GetSomeUnits(int start, int amount);
        IEnumerable<UnitDto> GetByFilter(int categoryId, int startPrice, int endPrice, List<int> sizesId, int skipItems, int amount);
        IEnumerable<UnitDto> GetByFilter(int categoryId, int amount);
        int GetAmountByFilter(int categoryId, int startPrice, int endPrice);
    }
}
