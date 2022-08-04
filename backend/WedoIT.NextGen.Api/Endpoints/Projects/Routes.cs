using JetBrains.Annotations;
using WedoIT.NextGen.Api.Endpoints.Projects.Create;
using WedoIT.NextGen.Api.Endpoints.Projects.Delete;
using WedoIT.NextGen.Api.Endpoints.Projects.Get;
using WedoIT.NextGen.Api.Endpoints.Projects.List;
using WedoIT.NextGen.Api.Endpoints.Projects.Update;
using WedoIT.NextGen.Api.Infrastructure.RouteMapping;

namespace WedoIT.NextGen.Api.Endpoints.Projects;

public static class Routes
{
    public const string ControllerName = "Projects";
    public const string List = $"{ControllerName}/";
    public const string Get = $"{ControllerName}/{{id}}";
    public const string Create = $"{ControllerName}/";
    public const string Update = $"{ControllerName}/{{id}}";
    public const string Delete = $"{ControllerName}/{{id}}";
}

[UsedImplicitly]
public class ProjectsRouteMappings : IRouteMapping
{
    public WebApplication AddRouteMappings(WebApplication app) => app
        .MapGetEndpoint()
        .MapListEndpoint()
        .MapCreateEndpoint()
        .MapUpdateEndpoint()
        .MapDeleteEndpoint();
}