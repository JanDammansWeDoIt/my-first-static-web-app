using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Data.Repositories.PersonRepository;

public interface IPersonRepository
{
    public Task<Person?> GetPersonById(Guid personId);
}