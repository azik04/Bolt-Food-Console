using Domain.Entity;
using Domain.Response;
namespace BLL.Services.Foods
{
    public interface IFoodService
    {
        IBaseResponse<List<Food>> GetAll();
        Task<IBaseResponse<Food>> Create();
        Task<IBaseResponse<Food>> Update();
        Task<IBaseResponse<Food>> Delete();
        IBaseResponse<List<Food>> GetByName();
        Task<IBaseResponse<Food>> GetById();
    }
}
