using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using ProjectRoutes = WedoIT.NextGen.Api.Endpoints.Projects.Routes;


namespace WedoIT.NextGen.Tests.ApiLayer;

[ExcludeFromCodeCoverage]
public class WebApplicationIntegrationTests
{
    [Fact]
    public async void IntegrationTest_CanCreateNewWebApplication_RoutingWorks()
    {
        // Arrange
        await using var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();
        
        // Act
       var projects = await client.GetAsync(ProjectRoutes.ControllerName);

        // Assert
        projects.EnsureSuccessStatusCode();
    }
}