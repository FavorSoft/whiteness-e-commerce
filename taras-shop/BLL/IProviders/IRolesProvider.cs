using DTO;

namespace BLL.IProviders
{
    public interface IRolesProvider : IProvider<RolesDto>
    {
        int GetIdByRole(string role);
    }
}
