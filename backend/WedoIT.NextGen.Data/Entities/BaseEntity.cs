
namespace WedoIT.NextGen.Data.Entities;

public class BaseEntity
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; set; }
}