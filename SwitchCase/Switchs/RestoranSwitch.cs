using BLL.Services.Restorans;
using BLL.Services.Users;
using Domain.Entity;

namespace SwitchCase.Switchs
{
    public class RestoranSwitch
    {
        private readonly RestoranService _restoranService;
        private readonly Role _userRole;
        public RestoranSwitch(RestoranService restoranService, Role userRole)
        {
            _restoranService = restoranService;
            _userRole = userRole;
        }

        public async Task ExecuteSwitch()
        {
            if (_userRole.Name == "Admin")
            {   
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Create Restoran");
                Console.WriteLine("2. Delete Restoran");
                Console.WriteLine("3. Get All Restorans");
                Console.WriteLine("4. Get Restoran By Name");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var createResponse = await _restoranService.Create();
                        Console.WriteLine(createResponse.Description);
                        break;
                    case "2":
                        var deleteResponse = await _restoranService.Delete();
                        Console.WriteLine(deleteResponse.Description);
                        break;
                    case "3":
                        var allResponse = _restoranService.GetAll();
                        Console.WriteLine(allResponse.Description);
                        break;
                    case "4":
                        var getByIdResponse = await _restoranService.GetByName();
                        Console.WriteLine(getByIdResponse.Description);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Get All Restorans");
                Console.WriteLine("2. Get Restoran By Name");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var allResponse = _restoranService.GetAll();
                        Console.WriteLine(allResponse.Description);
                        break;
                    case "2":
                        var getByIdResponse = await _restoranService.GetByName();
                        Console.WriteLine(getByIdResponse.Description);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
