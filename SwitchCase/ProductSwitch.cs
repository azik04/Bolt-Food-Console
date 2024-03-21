using BLL.Services.Foods;

namespace SwitchCase
{
    public class ProductSwitch
    {
        private readonly FoodService _foodService;

        public ProductSwitch(FoodService foodService)
        {
            _foodService = foodService;
        }

        public async Task ExecuteSwitch()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Create Food");
            Console.WriteLine("2. Delete Food");
            Console.WriteLine("3. Get All Foods");
            Console.WriteLine("4. Get Food By Id");
            Console.WriteLine("5. Get Food By Name");
            Console.WriteLine("6. Update Food");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var createResponse = await _foodService.Create();
                    Console.WriteLine(createResponse.Description);
                    break;
                case "2":
                    var deleteResponse = await _foodService.Delete();
                    Console.WriteLine(deleteResponse.Description);
                    break;
                case "3":
                    var allResponse = _foodService.GetAll();
                    Console.WriteLine(allResponse.Description);
                    break;
                case "4":
                    var getByIdResponse = await _foodService.GetById();
                    Console.WriteLine(getByIdResponse.Description);
                    break;
                case "5":
                    var getByNameResponse = _foodService.GetByName();
                    Console.WriteLine(getByNameResponse.Description);
                    break;
                case "6":
                    var updateResponse = await _foodService.Update();
                    Console.WriteLine(updateResponse.Description);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}