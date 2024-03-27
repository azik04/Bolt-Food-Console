using DAL.Repositories;
using Domain.Entity;
using Domain.Response;
using System.Data;

namespace BLL.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IBaseRepository<Food> _rep;
        public FoodService(IBaseRepository<Food> rep)
        {
            _rep = rep;
        }

        public async Task<IBaseResponse<Food>> Create()
        {
            try
            {
                Thread.Sleep(1000); 
                
                Console.WriteLine("Add Food Name:");
                var name = Console.ReadLine();
                Console.WriteLine("Add Food Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Add Food RestoranName:");
                string restoranId = Console.ReadLine();
                
                //var anna = _res.GetAll().FirstOrDefault(x => x.Name == restoranId);
                Food data = new Food()
                {
                    Name = name,
                    Description = description,
                    RestoranName = restoranId,
                };
                
                await _rep.Create(data);
                Console.Clear();
                Console.Beep();
                return new BaseResponse<Food>
                {
                    Data = data,
                    Description = "Food has been succesfully Create",

                    StatusCode = Domain.Enums.StatusCode.Ok
                };
                
            }
            catch (Exception ex)
            {
                return new BaseResponse<Food>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public async Task<IBaseResponse<Food>> Delete()
        {
            try
            {
                Console.WriteLine("Write the Name of Food you want to Delete");
                var food = Console.ReadLine();
                var remove = _rep.GetAll().FirstOrDefault(x => x.Name == food);
                await _rep.Delete(remove);
                Console.Clear();
                return new BaseResponse<Food>
                {
                    Data = remove,
                    Description = $"Food: {remove.Name} has been successfully Removed from {remove.RestoranName}",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Food>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public IBaseResponse<List<Food>> GetAll()
        {
            try
            {
                var data = _rep.GetAll().ToList();
                Console.Clear();
                foreach (var item in data)
                {
                    Console.WriteLine($"Food: {item.Name}, Descrption: {item.Description}, RestoranName: {item.RestoranName}");
                }
                
                return new BaseResponse<List<Food>>
                {
                    Data = data,
                    Description = "All foods have been successfully retrieved",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Food>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public async Task<IBaseResponse<Food>> GetById()
        {
            try
            {
                Console.WriteLine("Get Food By Id");
                var one = Console.ReadLine();
                var two = int.Parse(one);
                var data = _rep.GetAll().FirstOrDefault(x => x.Id == two);
                Console.Clear();
                Console.WriteLine($"Food: {data.Name}, Descrption: {data.Description}, RestoranName: {data.RestoranName}");
                return new BaseResponse<Food>
                {
                    Data = data,
                    Description = "Food has been succesfully found"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Food>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public IBaseResponse<List<Food>> GetByName()
        {
            try
            {
                Console.WriteLine("Get Food By Name ");
                var one = Console.ReadLine(); 
                var food = _rep.GetAll().Where(x => x.Name == one).ToList();
                Console.Clear();
                foreach (var item in food)
                {
                    Console.WriteLine($"Food Category:{item.Name}, Restoran:{item.RestoranName}");
                }
                return new BaseResponse<List<Food>>
                {
                    Data = food,
                    Description = "Category of Food have been succesfully found",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Food>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }
        public async Task<IBaseResponse<Food>> Update()
        {
            try
            {
                Console.WriteLine("Get Food By Id");
                var one = Console.ReadLine();
                var two = int.Parse(one);
                var obj = _rep.GetAll().SingleOrDefault(x=> x.Id == two);
                Console.WriteLine("Wright the Food Name you want to update:");
                var name = Console.ReadLine();
                Console.WriteLine("Wright the Food Description you want to update:");
                var description = Console.ReadLine();
                Console.WriteLine("Wright the Food RestoranName you want to update:");
                var restoranId = Console.ReadLine();
                //var anna = _res.GetAll().FirstOrDefault(x => x.Name == restoranId);
                obj.Name = name;
                obj.Description = description;
                obj.RestoranName = restoranId;
                await _rep.Update(obj);
                Console.Clear();
                return new BaseResponse<Food>
                {
                    Data = obj,
                    Description = "Food has been Successfully Update",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Food>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }

        }
    }
}
