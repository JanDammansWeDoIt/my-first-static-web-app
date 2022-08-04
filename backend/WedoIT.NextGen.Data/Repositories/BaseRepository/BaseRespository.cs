using AutoMapper;
using Microsoft.Extensions.Logging;
using WedoIT.NextGen.Data.Context;

namespace WedoIT.NextGen.Data.Repositories.BaseRepository;

public class BaseRespository 
{
    public readonly NextGenDbContext Context;
    public readonly IMapper Mapper;
    public readonly ILogger Logger;
    
    public BaseRespository(NextGenDbContext context, IMapper mapper, ILogger logger)
    {
        Context = context;
        Mapper = mapper;
        Logger = logger;
    }
}
