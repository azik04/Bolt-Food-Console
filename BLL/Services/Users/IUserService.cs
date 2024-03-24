using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Users
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Register();
        Task<IBaseResponse<User>> LogIn();
    }
}
