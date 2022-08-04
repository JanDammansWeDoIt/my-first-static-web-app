using AutoMapper;
using FluentValidation;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.ProjectService;

namespace WedoIT.NextGen.Api.Endpoints.Projects.Create;

public static class CreateEndpoint
{
    public static WebApplication MapCreateEndpoint(this WebApplication app)
    {
        app.MapPost(Routes.Create, InvokeAsync)
            .WithName("CreateProject")
            .Produces<CreateProjectResponse>(201)
            .WithTags(Routes.ControllerName);

        return app;
    }

    internal static async Task<IResult> InvokeAsync(ProjectRequest request, IProjectService service,
        IMapper mapper)
    {
        var model = mapper.Map<ProjectRequest, Project>(request);
        foreach (var blockId in request.Blocks)
        {
            model.Blocks.Add(new Block { Id = blockId });
        }

        var result = await service.CreateProject(model);
        var response = new Response<CreateProjectResponse>();
        return result.Match(
            project =>
            {
                var projectResponse = mapper.Map<Project, CreateProjectResponse>(project);
                response.Content = projectResponse;
                return Results.Created($"{Routes.ControllerName}/{projectResponse.Id}", response);
            },
            exception =>
            {
                if (exception is not ValidationException validationException) return Results.Problem();

                foreach (var error in validationException.Errors)
                {
                    response.ErrorMessages.Add(error.ErrorMessage);
                }

                return Results.BadRequest(response);
            });
    }
}