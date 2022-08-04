using WedoIT.NextGen.Data.Repositories.GenericRepository;
using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Service.Services.GenericService;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseDomainModel
{
    private readonly IGenericRepository<TEntity> _genericRepository;

    protected GenericService(IGenericRepository<TEntity> repository)
    {
        _genericRepository = repository;
    }

    public async Task Create(TEntity obj)
    {
        await _genericRepository.Create(obj);
    }

    public async Task<List<TEntity>> GetAll() => await _genericRepository.GetAll();

    public async Task<List<TEntity>> GetAllNonDeleted() => await _genericRepository.GetAllNonDeleted();

    public async Task<List<TEntity>> GetAllDeleted() => await _genericRepository.GetAllDeleted();

    public async Task<TEntity?> GetById(Guid id) => await _genericRepository.GetById(id);

    public async Task Update(TEntity obj)
    {
        await _genericRepository.Update(obj);
    }

    public async Task HardDelete(TEntity obj)
    {
        await _genericRepository.HardDelete(obj);
    }

    public async Task SoftDelete(Guid id)
    {
        await _genericRepository.SoftDelete(id);
    }
}