using BLL.Services.Foods;
using DAL.Repositories;
using Domain.Entity;
using Domain.Response;
using Domain.ViewModel.Restorans;

namespace BLL.Services.Restorans
{
    public class RestoranService : IRestoranService
    {
        private readonly IBaseRepository<Restoran> _rep;
        public RestoranService(IBaseRepository<Restoran> rep)
        {
            _rep = rep;
        }

        public async Task<IBaseResponse<Restoran>> Create()
        {
            Console.WriteLine("Wright a Restoran Name");
            var name = Console.ReadLine();
            Console.WriteLine("Wright a Restoran Description");
            var desc = Console.ReadLine();
            try
            {
                Restoran data = new Restoran()
                {
                    Name = name,
                    Description = desc,
                };
                await _rep.Create(data);
                return new BaseResponse<Restoran>
                {
                    Data = data,
                    Description = "Restoran has been succesfully Create",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Restoran>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public async Task<IBaseResponse<Restoran>> Delete()
        {
            try
            {
                Console.WriteLine("Wright a Restoran you want to Remove");
                var rem = Console.ReadLine();
                var remove = _rep.GetAll().FirstOrDefault(x => x.Name == rem);
                await _rep.Delete(remove);
                return new BaseResponse<Restoran>
                {
                    Data = remove,
                    Description = "Restoran has been successfully Removed",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Restoran>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public IBaseResponse<List<Restoran>> GetAll()
        {
            try
            {
                var data = _rep.GetAll().ToList();
                return new BaseResponse<List<Restoran>>
                {
                    Data = data,
                    Description = "All Restoran have been successfully retrieved",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Restoran>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        
        public async Task<IBaseResponse<Restoran>> GetByName()
        {
            try
            {
                Console.WriteLine("Wright a Restoran Name thats you tryna search");
                var one = Console.ReadLine();
                var food = _rep.GetAll().SingleOrDefault(x => x.Name == one);
                return new BaseResponse<Restoran>
                {
                    Data = food,
                    Description = "Category of Restoran have been succesfully found",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Restoran>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }
        public async Task<IBaseResponse<Restoran>> Update()
        {
            try
            {
                Console.WriteLine("Get Food By Id");
                var one = Console.ReadLine();
                var two = int.Parse(one);
                var obj = _rep.GetAll().SingleOrDefault(x => x.Id == two);
                Console.WriteLine("Wright the Restoran Name you want to update:");
                var name = Console.ReadLine();
                Console.WriteLine("Wright the Restoran Description you want to update:");
                var description = Console.ReadLine();
                obj.Name = name;
                obj.Description = description;
                await _rep.Update(obj);
                return new BaseResponse<Restoran>
                {
                    Data = obj,
                    Description = "Food has been Successfully Update",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Restoran>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }

        }
    }
}
