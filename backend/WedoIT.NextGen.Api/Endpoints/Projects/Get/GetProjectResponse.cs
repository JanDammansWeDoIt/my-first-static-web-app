using WedoIT.NextGen.Api.Endpoints.Responses;

namespace WedoIT.NextGen.Api.Endpoints.Projects.Get;

public class GetProjectResponse:BaseResponse
{
    public IEnumerable<BlockResponse> Blocks { get; set; } = Enumerable.Empty<BlockResponse>();   
}