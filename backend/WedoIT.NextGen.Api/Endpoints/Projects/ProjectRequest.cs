using System.Diagnostics.CodeAnalysis;

namespace WedoIT.NextGen.Api.Endpoints.Projects;

[ExcludeFromCodeCoverage]
public class ProjectRequest
{
    public string Name { get; set; } = null!;
    public Guid CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ClientName { get; set; } = null!;
    public string RepositoryUrl { get; set; } = null!;
    public bool NeedHosting { get; set; }
    public bool HasDatabase { get; set; }
    public string Domain { get; set; } = null!;
    public List<string> Types { get; set; } = null!;
    public DateTime LastModified { get; set; }

    public IEnumerable<Guid> Blocks { get; set; } = Enumerable.Empty<Guid>();
}