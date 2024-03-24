using Domain.Entity;
using Domain.Response;
namespace BLL.Services.Orders
{
    public interface IOrderService
    {
        IBaseResponse<List<Order>> GetAll();
        Task<IBaseResponse<Order>> Create();
        Task<IBaseResponse<Order>> Delete();
        IBaseResponse<List<Order>> GetByUser();
        Task<IBaseResponse<Order>> GetById();
    }
}
