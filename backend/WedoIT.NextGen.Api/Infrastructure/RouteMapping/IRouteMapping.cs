namespace WedoIT.NextGen.Api.Infrastructure.RouteMapping;

// Marker interface for setting up routes automatically
public interface IRouteMapping
{
    WebApplication AddRouteMappings(WebApplication app);
}