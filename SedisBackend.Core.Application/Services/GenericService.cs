using AutoMapper;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;

namespace SedisBackend.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Model> : IGenericService<SaveViewModel, ViewModel, Model>
            where SaveViewModel : class
            where ViewModel : class
            where Model : class
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Model> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task Update(SaveViewModel viewModel, int id)
        {
            Model entity = _mapper.Map<Model>(viewModel);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entitylist = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entitylist);
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel viewModel)
        {
            Model entity = _mapper.Map<Model>(viewModel);
            entity = await _repository.AddAsync(entity);
            SaveViewModel Savevm = _mapper.Map<SaveViewModel>(entity);
            return Savevm;
        }


        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Model entity = await _repository.GetEntityByIDAsync(id);

            SaveViewModel Savevm = _mapper.Map<SaveViewModel>(entity);
            return Savevm;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetEntityByIDAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
