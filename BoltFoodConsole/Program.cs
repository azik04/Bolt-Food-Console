using BLL.Services.Foods;
using BLL.Services.Menu;
using BLL.Services.Orderd;
using BLL.Services.Restorans;
using DAL;
using DAL.Repositories.Foods;
using DAL.Repositories.Orders;
using DAL.Repositories.Restorans;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase("Test");
        //optionsBuilder.UseSqlServer("Server=DESKTOP-FF5PAI4\\SQLEXPRESS;Database=BoltFood;Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=true;");
        var dbContext = new ApplicationDbContext(optionsBuilder.Options);
        MenuService menuService = new MenuService(new RestoranService(new RestoranRepository(dbContext), new FoodRepository(dbContext)),new FoodService( new FoodRepository(dbContext)),new OrderService(new OrderRepository(dbContext)));
        menuService.Menu();
        
    }
}
