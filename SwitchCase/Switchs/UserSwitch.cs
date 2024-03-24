using BLL.Services.Users;

namespace SwitchCase.Switchs
{
    public class UserSwitch
    {
        private readonly UserService _userService;
        public UserSwitch(UserService userService)
        {
            _userService = userService;
        }
        public async Task ExecuteSwitch()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Register");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var createResponse = await _userService.LogIn();
                    Console.WriteLine(createResponse.Description);
                    break;
                case "2":
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
