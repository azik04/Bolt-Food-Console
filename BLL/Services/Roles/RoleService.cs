using DAL.Repositories;
using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Roles
{
    
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<Role> _rep;
        public RoleService(IBaseRepository<Role> rep)
        {
            _rep = rep;
        }
        public async Task<IBaseResponse<Role>> Create()
        {
            Console.WriteLine("Wright the Roles");
            var userRole = Console.ReadLine();
            Role role = new Role();
            {
                role.Name = userRole;
            }
            await _rep.Create(role);
            return new BaseResponse<Role>()
            {
                Data = role,
                Description = "Role has been succesfully create",
                StatusCode = Domain.Enums.StatusCode.Ok
            };
        }
    }
}
