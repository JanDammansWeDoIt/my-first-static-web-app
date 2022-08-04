using System.Diagnostics.CodeAnalysis;

namespace WedoIT.NextGen.Api.Endpoints.Responses;

[ExcludeFromCodeCoverage]
public class PersonResponse : BaseResponse
{
    public string Email { get; set; } = null!;
    public string Nickname { get; set; } = null!;
    public DateTime LastModified { get; set; }
    public string? Picture { get; set; }
}