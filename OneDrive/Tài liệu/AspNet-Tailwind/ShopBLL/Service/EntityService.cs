using AutoMapper;
using Microsoft.Extensions.Logging;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Interface;

namespace ShopBussinessLogic.Service
{
    public class EntityService<T> : IEntityService<T> where T : class, new()
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<EntityService<T>> _logger;

        public EntityService(IRepository<T> repository, IMapper mapper, ILogger<EntityService<T>> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<T> AddAsync(T toAddDTO)
        {
            var addedEntity = await _repository.AddAsync(_mapper.Map<T>(toAddDTO));
            return addedEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _repository.GetByIdAsync(id);
            if (entityToDelete != null)
            {
                await _repository.DeleteAsync(id);
                _logger.LogInformation($"Entity of type {typeof(T)} with ID {id} deleted");
            }
            else
            {
                _logger.LogWarning($"Entity of type {typeof(T)} with ID {id} not found for deletion");
            }
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                return entity;
            }
            _logger.LogWarning($"Entity of type {typeof(T)} with ID {id} not found");
            return null;
        }

        public async Task<List<T>> GetListsAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetListAsync();
        }

        public async Task<T> UpdateAsync(T toUpdateDTO)
        {
            var entityToUpdate = await _repository.UpdateAsync(_mapper.Map<T>(toUpdateDTO));
            if (entityToUpdate != null)
            {
                _logger.LogInformation($"Entity of type {typeof(T)} updated with ID: {entityToUpdate}");
                return entityToUpdate;
            }
            _logger.LogWarning($"Entity of type {typeof(T)} not found for update");
            return null;
        }
    }
}
