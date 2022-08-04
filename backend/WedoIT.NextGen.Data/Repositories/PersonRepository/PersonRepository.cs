using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WedoIT.NextGen.Data.Context;
using WedoIT.NextGen.Data.Repositories.BaseRepository;
using WedoIT.NextGen.Domain.DomainModels;
using PersonEntity = WedoIT.NextGen.Data.Entities.Person;
using PersonModel = WedoIT.NextGen.Domain.DomainModels.Person;

namespace WedoIT.NextGen.Data.Repositories.PersonRepository;

public class PersonRepository : BaseRespository, IPersonRepository
{
    public async Task<Person?> GetPersonById(Guid personId)
    {
        if (personId == Guid.Empty) return null;
        var result =  await Context.Persons.FirstOrDefaultAsync(person => person.Id == personId);
        if (result == null) return null;
    
        var person = Mapper.Map<PersonEntity, PersonModel>(result);
        return person;
       }

    public PersonRepository(NextGenDbContext context, IMapper mapper, ILogger<BaseDomainModel> logger) : base(context, mapper, logger)
    {
    }
}