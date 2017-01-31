using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface IUnitProvider
    {
        void AddItem(DTO.Unit category);
        IEnumerable<DTO.Unit> GetAll();
        IEnumerable<DTO.Unit> GetSomeUnits(int start, int amount);
        IEnumerable<DTO.Unit> GetPopular(int amount);
        IEnumerable<DTO.Unit> GetRecommends();
        DTO.Unit GetById(int id);
        
    }
}
