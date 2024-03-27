using BLL.Services.Foods;
using BLL.Services.Orderd;
using BLL.Services.Restorans;
using Domain.Entity;

namespace BLL.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly RestoranService _restoranService;
        private readonly FoodService _foodService;
        private readonly OrderService _orderService;
        public MenuService (RestoranService restoranService, FoodService foodService, OrderService orderService)
        {
            _restoranService= restoranService;
            _foodService = foodService;
            _orderService = orderService;
        }
        public void Menu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Create Food");
                Console.WriteLine("2. Delete Food");
                Console.WriteLine("3. Get All Foods");
                Console.WriteLine("4. Get Food By Id");
                Console.WriteLine("5. Get Food By Name");
                Console.WriteLine("6. Update Food");
                Console.WriteLine("7. Create Restoran");
                Console.WriteLine("8. Delete Restoran");
                Console.WriteLine("9. Get All Restorans");
                Console.WriteLine("10. Get Restoran By Name");
                Console.WriteLine("11. Update Restoran");
                Console.WriteLine("12. Create Order");
                Console.WriteLine("13. Delete Order");
                Console.WriteLine("14. Get All Orders");
                Console.WriteLine("15. Get Order By Id");
                Console.WriteLine("16. Get Orders By UserName");
                Console.WriteLine("17. Update Order");
                Console.WriteLine("18. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var createResponse = _foodService.Create();
                        Console.WriteLine(createResponse.Result.Description);
                        break;
                    case "2":
                        var deleteResponse = _foodService.Delete();
                        Console.WriteLine(deleteResponse.Result.Description);
                        break;
                    case "3":
                        var allResponse = _foodService.GetAll();
                        Console.WriteLine(allResponse.Description);
                        break;
                    case "4":
                        var getByIdResponse = _foodService.GetById();
                        Console.WriteLine(getByIdResponse.Result.Description);
                        break;
                    case "5":
                        var getByNameResponse = _foodService.GetByName();
                        Console.WriteLine(getByNameResponse.Description);
                        break;
                    case "6":
                        var updateResponse = _foodService.Update();
                        Console.WriteLine(updateResponse.Result.Description);
                        break;
                    case "7":
                        var rcreateResponse = _restoranService.Create();
                        Console.WriteLine(rcreateResponse.Result.Description);
                        break;
                    case "8":
                        var rdeleteResponse = _restoranService.Delete();
                        Console.WriteLine(rdeleteResponse.Result.Description);
                        break;
                    case "9":
                        var rallResponse = _restoranService.GetAll();
                        Console.WriteLine(rallResponse.Description);
                        break;
                    case "10":
                        var rgetByIdResponse = _restoranService.GetByName();
                        Console.WriteLine(rgetByIdResponse.Result.Description);
                        break;
                    case "11":
                        var rupdateResponse = _restoranService.Update();
                        Console.WriteLine(rupdateResponse.Result.Description);
                        break;
                    case "12":
                        var ocreateResponse = _orderService.Create();
                        Console.WriteLine(ocreateResponse.Result.Description);
                        break;
                    case "13":
                        var odeleteResponse = _orderService.Delete();
                        Console.WriteLine(odeleteResponse.Result.Description);
                        break;
                    case "14":
                        var oallResponse = _orderService.GetAll();
                        Console.WriteLine(oallResponse.Description);
                        break;
                    case "15":
                        var ogetByIdResponse = _orderService.GetById();
                        Console.WriteLine(ogetByIdResponse.Result.Description);
                        break;
                    case "16":
                        var ogetByNameResponse = _orderService.GetByUser();
                        Console.WriteLine(ogetByNameResponse.Description);
                        break;
                    case "18":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
