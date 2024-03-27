using BLL.Services.Roles;
using BLL.Services.Users;

namespace SwitchCase.Switchs
{
    public class UserSwitch
    {
        private readonly UserService _userService;
        private readonly RoleService _role;
        public UserSwitch(UserService userService, RoleService role)
        {
            _userService = userService;
            _role = role;
        }
        public async Task ExecuteSwitch()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Create Roles:");
            Console.WriteLine("2. Log In");
            Console.WriteLine("3. Register");
            string choice = Console.ReadLine();
            //while(_userService.LogIn())
            switch (choice)
            {
                case "1":
                    var roleResponse = await _role.Create();
                    Console.WriteLine(roleResponse.Description);
                    break;
                case "2":
                    var createResponse = await _userService.LogIn();
                    Console.WriteLine(createResponse.Description);
                    break;
                case "3":
                    var deleteResponse = await _userService.Register();
                    Console.WriteLine(deleteResponse.Description);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
