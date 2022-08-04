namespace WedoIT.NextGen.Api.Utils;

public static class CustomHttpResults
{
    public static IResult MapperProblem<TSource, TDestination>(string? instance)
        where TSource : class
        where TDestination : class
        => Results.Problem(
            title: "There went something wrong when mapping the response",
            detail: $"Couldn't map {typeof(TSource)} to {typeof(TDestination)}",
            type: "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            statusCode: StatusCodes.Status500InternalServerError,
            instance: instance
        );
}