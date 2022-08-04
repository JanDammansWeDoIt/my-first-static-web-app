
using System.Collections.ObjectModel;

namespace WedoIT.NextGen.Domain.DomainModels;

public class Person : BaseDomainModel
{
    public string Email { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public DateTime LastModified { get; set; }
    public string? Picture { get; set; }

    
    public virtual ICollection<Block> Blocks { get; set; } = new Collection<Block>();
    public virtual ICollection<History> Histories { get; set; } = new HashSet<History>();
    public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
}