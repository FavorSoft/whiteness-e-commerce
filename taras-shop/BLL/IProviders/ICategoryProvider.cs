using DTO;
using System.Collections.Generic;

namespace BLL.IProviders
{
    public interface ICategoryProvider : IProvider<CategoriesDto>
    {
        List<CategoriesDto> getCategoryByInfo(int typeId, string category);
    }
}
