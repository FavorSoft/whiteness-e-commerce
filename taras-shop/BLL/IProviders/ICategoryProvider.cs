using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface ICategoryProvider
    {
        void AddItem(DTO.CategoriesDto category);
        IEnumerable<DTO.CategoriesDto> GetAll();
        DTO.CategoriesDto GetById(int id);
    }
}
