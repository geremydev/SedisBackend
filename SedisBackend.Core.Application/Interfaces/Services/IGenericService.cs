
namespace SedisBackend.Core.Application.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        Task Update(SaveViewModel viewModel, int id);
        Task<SaveViewModel> Add(SaveViewModel viewModel);
        Task Delete(int id);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<List<ViewModel>> GetAllViewModel();
    }
}