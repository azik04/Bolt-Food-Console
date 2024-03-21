using Domain.Entity;
using Domain.Response;
namespace BLL.Services.Orders
{
    public interface IOrderService
    {
        IBaseResponse<List<Order>> GetAll();
        Task<IBaseResponse<Order>> Create(Order order);
        Task<IBaseResponse<Order>> Delete(int id);

        ///user get his orders
        IBaseResponse<List<Order>> GetByUser(string name);
        Task<IBaseResponse<Order>> GetById(int id);
    }
}
