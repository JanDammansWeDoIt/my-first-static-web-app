using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using WedoIT.NextGen.Api.Endpoints.Projects;
using WedoIT.NextGen.Api.Mapper;
using WedoIT.NextGen.Domain.DomainModels;
using Xunit;

namespace WedoIT.NextGen.Tests.ApiLayer;

[ExcludeFromCodeCoverage]
public class MapperTests
{
    [Fact]
    public void AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());

        // Act

        // Assert
         //config.AssertConfigurationIsValid();
    }
}