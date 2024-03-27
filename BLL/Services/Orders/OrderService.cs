using BLL.Services.Orders;
using DAL.Repositories;
using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Orderd
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _rep;
        public OrderService(IBaseRepository<Order> rep)
        {
            _rep = rep;
        }

        public async Task<IBaseResponse<Order>> Create()
        {
            try
            {
                Console.WriteLine("Order FoodName:");
                var name = Console.ReadLine();
                Console.WriteLine("Order RestoranName:");
                string restoranId = Console.ReadLine();
                Console.WriteLine("UserName Order:");
                string userName = Console.ReadLine();
                Order data = new Order
                {
                    FoodName = name,
                    RestoranName = restoranId,
                    UserName = userName
                };
                await _rep.Create(data);
                return new BaseResponse<Order>
                {
                    Data = data,
                    Description = $"Order: {data.FoodName} from:{data.RestoranName}, for {data.UserName} has been succesfully Create",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public async Task<IBaseResponse<Order>> Delete()
        {
            try
            {
                Console.WriteLine("Remove Order by Id:");
                var rem = Console.ReadLine();
                var nan = int.Parse(rem);
                var remove = _rep.GetAll().FirstOrDefault(x => x.Id == nan);
                await _rep.Delete(remove);
                return new BaseResponse<Order>
                {
                    Data = remove,
                    Description = "Order has been successfully Removed",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public IBaseResponse<List<Order>> GetAll()
        {
            try
            {
                var data = _rep.GetAll().ToList();
                foreach (var item in data)
                {
                    Console.WriteLine($"Order: FoodName: {item.FoodName}, RestoranName {item.RestoranName}, UserName {item.UserName}");
                }
                return new BaseResponse<List<Order>>
                {
                    Data = data,
                    Description = "All Order have been successfully retrieved",
                    StatusCode = Domain.Enums.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Order>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public async Task<IBaseResponse<Order>> GetById()
        {
            try
            {
                Console.WriteLine("Get Order by Id:");
                var rem = Console.ReadLine();
                var nan = int.Parse(rem);
                var data = _rep.GetAll().FirstOrDefault(x => x.Id == nan);
                return new BaseResponse<Order>
                {
                    Data = data,
                    Description =$"Order: {data.FoodName} for {data.UserName} has been succesfully found"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }
        }

        public IBaseResponse<List<Order>> GetByUser()
        {
            try
            {
                Console.WriteLine("Wright your UserName:");
                var rem = Console.ReadLine();
                var user = _rep.GetAll().Where(x => x.UserName == rem).ToList();
                foreach (var item in user)
                {
                    Console.WriteLine($"Order: FoodName: {item.FoodName}, RestoranName {item.RestoranName}, UserName {item.UserName}");
                }
                return new BaseResponse<List<Order>>
                {
                    Data = user,
                    Description = "Order has been succesfully found"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Order>>
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enums.StatusCode.InternetServerError
                };
            }

        }
    }
}
