using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WedoIT.NextGen.Data.Context;
using WedoIT.NextGen.Data.Repositories.BaseRepository;
using WedoIT.NextGen.Domain.DomainModels;
using BlockModel = WedoIT.NextGen.Domain.DomainModels.Block;
using BlockEntity = WedoIT.NextGen.Data.Entities.Block;

namespace WedoIT.NextGen.Data.Repositories.BlockRepository;

public class BlockRepository: BaseRespository, IBlockRepository
{
    public async Task<BlockModel> GetById(Guid blockId)
    {
        BlockModel block = null;
        if (blockId != Guid.Empty)
        {
            var result =  await Context.Blocks.FirstOrDefaultAsync(block => block.Id == blockId);
            block = Mapper.Map<BlockEntity,BlockModel>(result);
        }
        return block;
    }

    public async Task<List<Block>> GetBlocksByListIds(List<Guid> blockIds)
    {
        var result =  await Context.Blocks.Where(block => blockIds.Contains(block.Id)).ToListAsync();
        var  blocks = Mapper.Map<List<BlockEntity>,List<BlockModel>>(result);
        return blocks;
    }

    public BlockRepository(NextGenDbContext context, IMapper mapper, ILogger<BaseDomainModel> logger) : base(context, mapper, logger)
    {
    }
}