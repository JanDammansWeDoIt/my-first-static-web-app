using System.Diagnostics.CodeAnalysis;

namespace WedoIT.NextGen.Api.Endpoints;

[ExcludeFromCodeCoverage]
public class BaseResponse
{
    public Guid Id { get; set; }
}