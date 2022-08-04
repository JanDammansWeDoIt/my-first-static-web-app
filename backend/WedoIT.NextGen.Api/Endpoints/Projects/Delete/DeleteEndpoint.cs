using WedoIT.NextGen.Service.Services.ProjectService;

namespace WedoIT.NextGen.Api.Endpoints.Projects.Delete;

public static class DeleteEndpoint
{
    public static WebApplication MapDeleteEndpoint(this WebApplication app)
    {
        app.MapDelete(Routes.Delete, InvokeAsync)
            .WithName("DeleteProject")
            .Produces(204)
            .WithTags(Routes.ControllerName);

        return app;
    }

    internal static async Task<IResult> InvokeAsync(Guid projectId, IProjectService service) => null;
    // => await GenericEndpointOperators.SoftDeleteEntity(projectId, service);
}