using WedoIT.NextGen.Data.Repositories.BaseRepository;
using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Data.Repositories.BlockRepository;

public interface IBlockRepository 
{
    public Task<Block> GetById(Guid blockId);
    public Task<List<Block>> GetBlocksByListIds(List<Guid> blockIds);
}