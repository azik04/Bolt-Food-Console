using Domain.Entity;
using Domain.Response;

namespace BLL.Services.Restorans
{
    public interface IRestoranService
    {
        IBaseResponse<List<Restoran>> GetAll();
        Task<IBaseResponse<Restoran>> Create(Restoran food);
        Task<IBaseResponse<Restoran>> Update(Restoran food);
        Task<IBaseResponse<Restoran>> Delete(string name);
        IBaseResponse<List<Restoran>> GetByName(string name);
        Task<IBaseResponse<Restoran>> GetById(int id);
    }
}
