using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Roles
{
    public interface IRoleService
    {
        Task<IBaseResponse<Role>> Create();
    }
}
