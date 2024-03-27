using DAL.Repositories.Roles;
using DAL.Repositories.Users;
using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserRepository _rep;
        private readonly RoleRepository _role;
        public UserService(UserRepository rep, RoleRepository role)
        {
            _rep = rep;
            _role = role;
        }
        public async Task<IBaseResponse<User>> LogIn()
        {
            try
            {
                Console.WriteLine("Wright your UserName:");
                var name = Console.ReadLine();
                Console.WriteLine("Wright your Password");
                string password = Console.ReadLine();
                var log = _rep.GetAll().SingleOrDefault(x => x.Name == name && x.Password == password);
                return new BaseResponse<User>
                {
                    Description = "User has been succussfully LogIN",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.UserNotFound
                };
            }
        }

        public async Task<IBaseResponse<User>> Register()
        {
            try
            {
                var roles = _role.GetAll();
                foreach (var item in roles)
                {
                    Console.WriteLine($"Role: {item.Name}");
                }
                Console.WriteLine("Wright your UserName:");
                var name = Console.ReadLine();
                Console.WriteLine("Wright your Password");
                string password = Console.ReadLine();
                Console.WriteLine("Admin or User??");
                var roleName = Console.ReadLine();

                var role = await _role.GetByName(roleName);

                if (role == null)
                {
                    
                    return new BaseResponse<User>()
                    {
                        Description = "Role does not exist",
                        StatusCode = Domain.Enums.StatusCode.InternetServerError
                    };
                }

                User data = new User()
                {
                    Name = name,
                    Password = password,
                    Role = role,
                };
                await _rep.Create(data);
                return new BaseResponse<User>
                {
                    Data = data,
                    Description = "User has been succesfully Registered",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }
    }
}
