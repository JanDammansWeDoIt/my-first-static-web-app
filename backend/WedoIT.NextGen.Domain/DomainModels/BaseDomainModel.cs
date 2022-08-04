
namespace WedoIT.NextGen.Domain.DomainModels;

public class BaseDomainModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool IsDeleted { get; set; }
}