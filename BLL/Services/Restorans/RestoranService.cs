//using BLL.Services.Foods;
//using DAL.Repositories;
//using Domain.Entity;
//using Domain.Response;

//namespace BLL.Services.Restorans
//{
//    public class FoodService : IRestoranService
//    {
//        private readonly IBaseRepository<Restoran> _rep;
//        public FoodService(IBaseRepository<Restoran> rep)
//        {
//            _rep = rep;
//        }

//        public async Task<IBaseResponse<Restoran>> Create(Restoran food)
//        {
//            try
//            {
//                Restoran data = new Restoran()
//                {
//                    Name = food.Name,
//                    Description = food.Description,
//                    Food = food.Food
//                };
//                await _rep.Create(data);
//                return new BaseResponse<Restoran>
//                {
//                    Data = data,
//                    Description = "Restoran has been succesfully Create",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Restoran>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public async Task<IBaseResponse<Restoran>> Delete(string name)
//        {
//            try
//            {
//                var remove = _rep.GetAll().FirstOrDefault(x => x.Name == name);
//                await _rep.Delete(remove);
//                return new BaseResponse<Restoran>
//                {
//                    Data = remove,
//                    Description = "Restoran has been successfully Removed",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Restoran>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public IBaseResponse<List<Restoran>> GetAll()
//        {
//            try
//            {
//                var data = _rep.GetAll().ToList();
//                return new BaseResponse<List<Restoran>>
//                {
//                    Data = data,
//                    Description = "All Restoran have been successfully retrieved",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<List<Restoran>>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public async Task<IBaseResponse<Restoran>> GetById(int id)
//        {
//            try
//            {
//                var data = _rep.GetAll().FirstOrDefault(x => x.Id == id);
//                return new BaseResponse<Restoran>
//                {
//                    Data = data,
//                    Description = "Restoran has been succesfully found"
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Restoran>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }

//        public IBaseResponse<List<Restoran>> GetByName(string name)
//        {
//            try
//            {
//                var food = _rep.GetAll().Where(x => x.Name == name).ToList();
//                return new BaseResponse<List<Restoran>>
//                {
//                    Data = food,
//                    Description = "Category of Restoran have been succesfully found",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<List<Restoran>>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }
//        }
//        public async Task<IBaseResponse<Restoran>> Update(Restoran food)
//        {
//            try
//            {
//                var obj = _rep.GetAll().SingleOrDefault(x => x.Id == food.Id);
//                obj.Name = food.Name;
//                obj.Description = food.Description;
//                obj.Food = food.Food;
//                await _rep.Update(obj);
//                return new BaseResponse<Restoran>
//                {
//                    Data = obj,
//                    Description = "Restoran has been Successfully Update",
//                    StatusCode = Domain.Enums.StatusCode.Ok
//                };
//            }
//            catch (Exception ex)
//            {
//                return new BaseResponse<Restoran>
//                {
//                    Description = ex.Message,
//                    StatusCode = Domain.Enums.StatusCode.InternetServerError
//                };
//            }

//        }
//    }
//}
