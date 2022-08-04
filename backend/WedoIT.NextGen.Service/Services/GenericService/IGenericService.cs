namespace WedoIT.NextGen.Service.Services.GenericService;

public interface IGenericService<TEntity> where TEntity : class
{
    Task Create(TEntity obj);
    Task<List<TEntity>> GetAll();
    Task<List<TEntity>> GetAllNonDeleted();
    Task<List<TEntity>> GetAllDeleted();
    Task<TEntity?> GetById(Guid id);
    Task Update(TEntity obj);
    Task HardDelete(TEntity obj);
    Task SoftDelete(Guid id);
}