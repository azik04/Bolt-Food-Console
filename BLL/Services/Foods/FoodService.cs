using DAL.Repositories;
using Domain.Entity;
using Domain.Response;

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
                
                Console.WriteLine("Add Food Name:");
                var name = Console.ReadLine();
                Console.WriteLine("Add Food Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Add Food RestoranId:");
                string restoranId = Console.ReadLine();
                var pa = int.Parse(restoranId);
                Food data = new Food()
                {
                    Name = name,
                    Description = description,
                    RestoranId = pa,
                };
                await _rep.Create(data);
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
                return new BaseResponse<Food>
                {
                    Data = remove,
                    Description = "Food has been successfully Removed",
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
                Console.WriteLine("Wright the Food RestoranId you want to update:");
                var restoranId = Console.ReadLine();
                var upd = int.Parse(restoranId);
                obj.Name = name;
                obj.Description = description;
                obj.RestoranId = upd;
                await _rep.Update(obj);
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
