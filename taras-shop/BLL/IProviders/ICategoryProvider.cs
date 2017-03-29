using DTO;

namespace BLL.IProviders
{
    public interface ICategoryProvider : IProvider<CategoriesDto>
    {
        CategoriesDto getCategoryByInfo(int typeId, string category);
    }
}
