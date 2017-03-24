using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IProviders
{
    public interface ICategoryProvider : IProvider<CategoriesDto>
    {
        CategoriesDto getCategoryByInfo(int typeId, string category);
    }
}
