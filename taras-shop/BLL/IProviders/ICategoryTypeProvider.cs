using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface ICategoryTypeProvider
    {
        void AddItem(DTO.CategoryType categoryType);
        IEnumerable<DTO.CategoryType> GetAll();
        DTO.CategoryType GetById(int id);
    }
}
