using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUnitProvider
    {
        void AddItem(DTO.UnitDto category);
        IEnumerable<DTO.UnitDto> GetAll();
        IEnumerable<DTO.UnitDto> GetSomeUnits(int start, int amount);
        IEnumerable<DTO.UnitDto> GetPopular(int amount);
        IEnumerable<DTO.UnitDto> GetRecommends();
        DTO.UnitDto GetById(int id);
        
    }
}
