using BLL.Services.Foods;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Foods;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SwitchCase;

internal class Program
{
    private static void Main(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-FF5PAI4\\SQLEXPRESS;Database=bolt;Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=true;");

        var dbContext = new ApplicationDbContext(optionsBuilder.Options);

        IBaseRepository<Food> foodRepository = new FoodRepository(dbContext);
        FoodService foodService = new FoodService(foodRepository);
        ProductSwitch productSwitch = new ProductSwitch(foodService);

        productSwitch.ExecuteSwitch();
    }
}