namespace WedoIT.NextGen.Data.Entities;

public class ProjectBlock: BaseEntity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public Guid BlockId { get; set; }
    public Block Block { get; set; }
}