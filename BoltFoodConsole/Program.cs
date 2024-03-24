using BLL.Services.Foods;
using BLL.Services.Orderd;
using BLL.Services.Restorans;
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
        optionsBuilder.UseSqlServer("Server=DESKTOP-FF5PAI4\\SQLEXPRESS;Database=bolt;Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=true;");

        
        var dbContext = new ApplicationDbContext(optionsBuilder.Options);
        IBaseRepository<User> userRepository = new UserRepository(dbContext);
        IBaseRepository<Role> roleRepository = new RoleRepository(dbContext);
        IBaseRepository<Order> orderRepository = new OrderRepository(dbContext);
        IBaseRepository<Restoran> restoranRepository = new RestoranRepository(dbContext);
        IBaseRepository<Food> foodRepository = new FoodRepository(dbContext);
        UserService userService = new UserService(userRepository, Role or userRole);
        RestoranService restoranService = new RestoranService(restoranRepository);
        OrderService orderService = new OrderService(orderRepository);
        FoodService foodService = new FoodService(foodRepository);
        FoodSwitch productSwitch = new FoodSwitch(foodService, userRole);
        productSwitch.ExecuteSwitch();
    }
}