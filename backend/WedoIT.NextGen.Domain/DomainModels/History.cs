
namespace WedoIT.NextGen.Domain.DomainModels;

public class History : BaseDomainModel
{
    public DateTime Date { get; set; }
    public string Field { get; set; } = null!;
    public string Reason { get; set; } = null!;
    public Guid DoneByPersonId { get; set; }
    public string OldValue { get; set; } = null!;
    public string NewValue { get; set; } = null!;
    public string Action { get; set; } = null!;
    public Guid StatusId { get; set; }
    public Guid ProjectId { get; set; }
    public Guid PersonId { get; set; }
    public Guid BlockId { get; set; }

    public virtual Person Person { get; set; } = null!;
    public virtual Project Project { get; set; } = null!;
    public virtual Block Block { get; set; } = null!;
}