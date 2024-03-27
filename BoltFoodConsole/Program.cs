using BLL.Services.Foods;
using BLL.Services.Orderd;
using BLL.Services.Orders;
using BLL.Services.Restorans;
using BLL.Services.Roles;
using BLL.Services.Users;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Foods;
using DAL.Repositories.Orders;
using DAL.Repositories.Restorans;
using DAL.Repositories.Roles;
using DAL.Repositories.Users;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SwitchCase.Switchs;

internal class Program
{
    private static void Main(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase("Test");
        var dbContext = new ApplicationDbContext(optionsBuilder.Options);
        FoodService foodService = new FoodService(new FoodRepository(dbContext), new RestoranRepository(dbContext));
        RestoranService restoranService = new RestoranService(new RestoranRepository(dbContext), new FoodRepository(dbContext));
        OrderService orderService = new OrderService(new OrderRepository(dbContext));
        //Role role = new Role();
        //User user = new User();
        ////IBaseRepository<User> userRepository = new UserRepository(dbContext);
        ////IBaseRepository<Role> roleRepository = new RoleRepository(dbContext);
        RoleRepository roleRepository = new RoleRepository(dbContext);
        UserRepository userRepository = new UserRepository(dbContext);
        //IBaseRepository<Order> orderRepository = new OrderRepository(dbContext);
        //IBaseRepository<Restoran> restoranRepository = new RestoranRepository(dbContext);
        //IBaseRepository<Food> foodRepository = new FoodRepository(dbContext);
        UserService userService = new UserService(userRepository, roleRepository);
        //RestoranService restoranService = new RestoranService(restoranRepository);
        //OrderService orderService = new OrderService(orderRepository);
        RoleService roleService = new RoleService(roleRepository);
        //FoodService foodService = new FoodService(foodRepository);
        //FoodSwitch productSwitch = new FoodSwitch(foodService, role,user);
        UserSwitch userSwitch = new UserSwitch(userService,roleService);
        //RestoranSwitch restoranSwitch = new RestoranSwitch(restoranService, role);
        //OrderSwitch orderSwitch = new OrderSwitch(orderService,role);

        userSwitch.ExecuteSwitch();
        //userSwitch.ExecuteSwitch();
        // restoranSwitch.ExecuteSwitch();
        // orderSwitch.ExecuteSwitch();
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
                    var createResponse = foodService.Create();
                    Console.WriteLine(createResponse.Result.Description);
                    break;
                case "2":
                    var deleteResponse = foodService.Delete();
                    Console.WriteLine(deleteResponse.Result.Description);
                    break;
                case "3":
                    var allResponse = foodService.GetAll();
                    Console.WriteLine(allResponse.Description);
                    break;
                case "4":
                    var getByIdResponse = foodService.GetById();
                    Console.WriteLine(getByIdResponse.Result.Description);
                    break;
                case "5":
                    var getByNameResponse = foodService.GetByName();
                    Console.WriteLine(getByNameResponse.Description);
                    break;
                case "6":
                    var updateResponse = foodService.Update();
                    Console.WriteLine(updateResponse.Result.Description);
                    break;
                case "7":
                    var rcreateResponse = restoranService.Create();
                    Console.WriteLine(rcreateResponse.Result.Description);
                    break;
                case "8":
                    var rdeleteResponse = restoranService.Delete();
                    Console.WriteLine(rdeleteResponse.Result.Description);
                    break;
                case "9":
                    var rallResponse = restoranService.GetAll();
                    Console.WriteLine(rallResponse.Description);
                    break;
                case "10":
                    var rgetByIdResponse = restoranService.GetByName();
                    Console.WriteLine(rgetByIdResponse.Result.Description);
                    break;
                case "11":
                    var rupdateResponse = restoranService.Update();
                    Console.WriteLine(rupdateResponse.Result.Description);
                    break;
                case "12":
                    var ocreateResponse =  orderService.Create();
                    Console.WriteLine(ocreateResponse.Result.Description);
                    break;
                case "13":
                    var odeleteResponse =  orderService.Delete();
                    Console.WriteLine(odeleteResponse.Result.Description);
                    break;
                case "14":
                    var oallResponse = orderService.GetAll();
                    Console.WriteLine(oallResponse.Description);
                    break;
                case "15":
                    var ogetByIdResponse =  orderService.GetById();
                    Console.WriteLine(ogetByIdResponse.Result.Description);
                    break;
                case "16":
                    var ogetByNameResponse = orderService.GetByUser();
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
