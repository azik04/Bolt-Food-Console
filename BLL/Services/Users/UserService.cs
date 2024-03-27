using DAL.Repositories.Users;
using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserRepository _rep;
        public UserService(UserRepository rep)
        {
            _rep = rep;
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
                Console.WriteLine("Wright your UserName:");
                var name = Console.ReadLine();
                Console.WriteLine("Wright your Password");
                string password = Console.ReadLine();
                Console.WriteLine("Admin or User??");
                var roleName = Console.ReadLine();

               

                User data = new User()
                {
                    Name = name,
                    Password = password,
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
