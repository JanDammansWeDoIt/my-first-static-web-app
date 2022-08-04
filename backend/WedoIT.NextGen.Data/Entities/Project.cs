namespace WedoIT.NextGen.Data.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = null!;
    public Guid CreatorId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string ClientName { get; set; } = null!;
    
    
    public string RepositoryUrl { get; set; } = null!;
    
    public bool NeedHosting { get; set; }
    
    public bool HasDatabase { get; set; }
    
    public string Domain { get; set; } = null!;
    
    public string Types { get; set; } = null!;
    
    public string Status { get; set; } = null!;
    
    public DateTime LastModified { get; set; }
    public List<ProjectBlock> ProjectBlocks { get; set; } = new ();
    

    public virtual Person Creator { get; set; } = null!;
    public virtual IEnumerable<History> Histories { get; set; } = new List<History>();
}