using WedoIT.NextGen.Api.Endpoints.Responses;

namespace WedoIT.NextGen.Api.Endpoints.Projects.List;

public class ListProjectResponse:ProjectResponse
{
    public IEnumerable<BlockResponse> Blocks { get; set; } = Enumerable.Empty<BlockResponse>();     
}