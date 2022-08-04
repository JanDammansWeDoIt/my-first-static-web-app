using System.Collections.ObjectModel;

namespace WedoIT.NextGen.Data.Entities;

public class Block : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Command { get; set; } = null!;
    public Guid CreatorId { get; set; }

    public virtual IEnumerable<History> Histories { get; set; } = new List<History>();
    public virtual IEnumerable<ProjectBlock> ProjectBlocks { get; set; } = new List<ProjectBlock>();
    public virtual Person Creator { get; set; }
}