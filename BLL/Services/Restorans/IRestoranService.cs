using Domain.Entity;
using Domain.Response;
using Domain.ViewModel.Restorans;

namespace BLL.Services.Restorans
{
    public interface IRestoranService
    {
        IBaseResponse<List<Restoran>> GetAll();
        Task<IBaseResponse<Restoran>> Create();
        Task<IBaseResponse<Restoran>> Update();
        Task<IBaseResponse<Restoran>> Delete();
        Task<IBaseResponse<Restoran>> GetByName();
    }
}
