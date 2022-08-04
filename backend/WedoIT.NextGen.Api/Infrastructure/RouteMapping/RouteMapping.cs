using WedoIT.NextGen.Api.Infrastructure.RouteMapping;

// Discoverability on WebApplication
// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

public static class RouteMapping
{
    public static WebApplication AddRouteMappings(this WebApplication app)
    {
        if (app is null) throw new ArgumentNullException(nameof(app));

        foreach (var routeMapping in typeof(IRouteMapping).Assembly.ExportedTypes
                     .Where(ItIsIRouteMappingImplementation)
                     .Select(Activator.CreateInstance)
                     .Cast<IRouteMapping>())
        {
            routeMapping?.AddRouteMappings(app);
        }

        return app;
    }

    private static bool ItIsIRouteMappingImplementation(Type type)
        => typeof(IRouteMapping).IsAssignableFrom(type) && !type.IsAbstract;
}