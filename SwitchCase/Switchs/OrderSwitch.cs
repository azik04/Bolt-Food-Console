using BLL.Services.Orderd;
using Domain.Entity;

namespace SwitchCase.Switchs
{
    public class OrderSwitch
    {
        private readonly OrderService _orderService;
        private readonly Role _userRole;
        public OrderSwitch(OrderService orderService, Role userRole)
        {
            _orderService = orderService;
            _userRole = userRole;
        }
        public async Task ExecuteSwitch()
        {
            if (_userRole.Name =="Admin")
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Delete Order");
                Console.WriteLine("3. Get All Orders");
                Console.WriteLine("4. Get Order By Id");
                Console.WriteLine("5. Get Orders By UserName");
                Console.WriteLine("6. Update Order");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var createResponse = await _orderService.Create();
                        Console.WriteLine(createResponse.Description);
                        break;
                    case "2":
                        var deleteResponse = await _orderService.Delete();
                        Console.WriteLine(deleteResponse.Description);
                        break;
                    case "3":
                        var allResponse = _orderService.GetAll();
                        Console.WriteLine(allResponse.Description);
                        break;
                    case "4":
                        var getByIdResponse = await _orderService.GetById();
                        Console.WriteLine(getByIdResponse.Description);
                        break;
                    case "5":
                        var getByNameResponse = _orderService.GetByUser();
                        Console.WriteLine(getByNameResponse.Description);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Delete Order");
                Console.WriteLine("3. Get All Orders");
                Console.WriteLine("4. Get Order By Id");
                Console.WriteLine("5. Get Orders By UserName");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var createResponse = await _orderService.Create();
                        Console.WriteLine(createResponse.Description);
                        break;
                    case "2":
                        var deleteResponse = await _orderService.Delete();
                        Console.WriteLine(deleteResponse.Description);
                        break;
                    case "3":
                        var allResponse = _orderService.GetAll();
                        Console.WriteLine(allResponse.Description);
                        break;
                    case "4":
                        var getByIdResponse = await _orderService.GetById();
                        Console.WriteLine(getByIdResponse.Description);
                        break;
                    case "5":
                        var getByNameResponse = _orderService.GetByUser();
                        Console.WriteLine(getByNameResponse.Description);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
