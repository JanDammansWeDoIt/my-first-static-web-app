using AutoMapper;
using WedoIT.NextGen.Service.Services.ProjectService;

namespace WedoIT.NextGen.Api.Endpoints.Projects.Update;

public static class UpdateEndpoint
{
    public static WebApplication MapUpdateEndpoint(this WebApplication app)
    {
        app.MapPut(Routes.Update, InvokeAsync)
            .WithName("UpdateProject")
            .Produces(204)
            .WithTags(Routes.ControllerName);
        return app;
    }

    internal static async Task<IResult> InvokeAsync(ProjectRequest request, IProjectService service,
        IMapper mapper) => null;
    //   => await GenericEndpointOperators.CreateEntity(request, service, mapper);
}