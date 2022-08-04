using AutoMapper;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.ProjectService;

namespace WedoIT.NextGen.Api.Endpoints.Projects.List;

public static class ListEndpoint
{
    public static WebApplication MapListEndpoint(this WebApplication app)
    {
        app.MapGet(Routes.List, InvokeAsync)
            .WithName("GetAllProjects")
            .Produces<ListProjectResponse>()
            .WithTags(Routes.ControllerName);

        return app;
    }

    internal static async Task<IResult> InvokeAsync(IProjectService service, IMapper mapper)
    {
        var result = await service.GetAllProjects();
        var mappedProjects = mapper.Map<List<Project>, List<ListProjectResponse>>(result);
        return Results.Ok( (mappedProjects));
    }
}