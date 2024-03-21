//using BLL.Services.Orders;
//using DAL.Repositories;
//using Domain.Entity;
//using Domain.Response;

//namespace BLL.Services.Orderd
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IBaseRepository<Order> _rep;
//        public OrderService(IBaseRepository<Order> rep)
//        {
//            _rep = rep;
//        }

//        public async Task<IBaseResponse<Order>> Create(Order order)
//        {
//            try
//            {
//                Order data = new Order
//                {
//                    FoodName = order.FoodName,
//                    RestoranName = order.RestoranName,
//                };
//                await _rep.Create(data);
//                return new BaseResponse<Order>
//                {
//                    Data = data,
//                    Description = "Order has been succesfully Create",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Order>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public async Task<IBaseResponse<Order>> Delete(int id)
//        {
//            try
//            {
//                var remove = _rep.GetAll().FirstOrDefault(x => x.Id == id);
//                await _rep.Delete(remove);
//                return new BaseResponse<Order>
//                {
//                    Data = remove,
//                    Description = "Food has been successfully Removed",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Order>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public IBaseResponse<List<Order>> GetAll()
//        {
//            try
//            {
//                var data = _rep.GetAll().ToList();
//                return new BaseResponse<List<Order>>
//                {
//                    Data = data,
//                    Description = "All foods have been successfully retrieved",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<List<Order>>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public async Task<IBaseResponse<Order>> GetById(int id)
//        {
//            try
//            {
//                var data = _rep.GetAll().FirstOrDefault(x => x.Id == id);
//                return new BaseResponse<Order>
//                {
//                    Data = data,
//                    Description = "Food has been succesfully found"
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Order>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public IBaseResponse<List<Order>> GetByUser(string name)
//        {
//            try
//            {
//                var user = _rep.GetAll().Where(x => x.UserName == name).ToList();
//                return new BaseResponse<List<Order>>
//                {
//                    Data = user,
//                    Description = "Food has been succesfully found"
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<List<Order>>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }

//        }
//    }
//}
