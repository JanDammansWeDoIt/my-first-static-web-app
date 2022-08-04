namespace WedoIT.NextGen.Api.Endpoints.Projects;

public class ProjectResponse : BaseResponse
{
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string ClientName { get; set; } = null!;
    public string RepositoryUrl { get; set; } = null!;
    public bool NeedHosting { get; set; }
    public bool HasDatabase { get; set; }
    public string Domain { get; set; } = null!;
    public List<string> Types { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime LastModified { get; set; }
}