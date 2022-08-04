using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WedoIT.NextGen.Data.Context;
using WedoIT.NextGen.Data.Entities;

namespace WedoIT.NextGen.Data.Repositories.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly NextGenDbContext _context;
    private readonly ILogger<TEntity> _logger;

    protected GenericRepository(NextGenDbContext context, ILogger<TEntity> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Create(TEntity entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("{Type} has been saved", entity.GetType());
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public virtual Task<List<TEntity>> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task<List<TEntity>> GetAllNonDeleted()
    {
        var entities = await GetAll();
        return entities.Where(x => !x.IsDeleted).ToList();
    }

    public async Task<List<TEntity>> GetAllDeleted()
    {
        var entities = await GetAll();
        return entities.Where(x => x.IsDeleted).ToList();
    }

    public virtual Task<TEntity?> GetById(Guid id)
    {
        try
        {
            return _context.Set<TEntity>().Where(t => t.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task Update(TEntity entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("{Type} with {Id} has been updated", entity.GetType(), entity.Id);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task HardDelete(TEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("{Type} with {Id} has been hard-deleted", entity.GetType(), entity.Id);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task SoftDelete(Guid id)
    {
        try
        {
            var entity = await _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null) return;
            entity.IsDeleted = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("{Type} with {Id} has been soft-deleted", entity.GetType(), entity.Id);
        }
        catch (Exception e)
        {
            _logger.LogError("{Message}", e.Message);
            throw;
        }
    }
}