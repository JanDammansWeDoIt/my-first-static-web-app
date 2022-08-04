using AutoMapper;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.ProjectService;

namespace WedoIT.NextGen.Api.Endpoints.Projects.Get;

public static class GetEndpoint
{
    public static WebApplication MapGetEndpoint(this WebApplication app)
    {
        app.MapGet(Routes.Get, InvokeAsync)
            .WithName("GetProject")
            .Produces<List<GetProjectResponse>>()
            .WithTags(Routes.ControllerName);

        return app;
    }

    internal static async Task<IReadOnlyList<Project>> InvokeAsync(Guid id, IProjectService service, IMapper mapper)
        => await service.GetAllProjects();
}