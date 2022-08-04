namespace WedoIT.NextGen.Domain.DomainModels;

public class Project : BaseDomainModel
{
    public string Name { get; set; } 
    public Guid CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ClientName { get; set; } 
    public string RepositoryUrl { get; set; }
    public bool NeedHosting { get; set; }
    public bool HasDatabase { get; set; }
    public string Domain { get; set; } 
    public List<string> Types { get; set; } 
    public string Status { get; set; }
    public DateTime LastModified { get; set; } 


    public List<Block> Blocks { get; set; } = new List<Block>();

    public virtual Person Creator { get; set; } = null!;
    
    public virtual IEnumerable<History> Histories { get; set; } = new List<History>();
}