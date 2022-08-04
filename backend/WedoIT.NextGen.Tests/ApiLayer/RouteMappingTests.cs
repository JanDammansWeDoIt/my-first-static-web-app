using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace WedoIT.NextGen.Tests.ApiLayer;

[ExcludeFromCodeCoverage]
public class RouteMappingTests
{
    [Fact]
    public void AddRouteMapping_WebApplicationIsNull_ReturnsArgumentNullException()
    {
        // Arrange
        var subject = () => RouteMapping.AddRouteMappings(null!);

        // Act
        subject.Should().Throw<ArgumentNullException>();
    }
}