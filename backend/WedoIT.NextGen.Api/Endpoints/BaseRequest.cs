using System.Diagnostics.CodeAnalysis;

namespace WedoIT.NextGen.Api.Endpoints;

[ExcludeFromCodeCoverage]
public class BaseRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
}