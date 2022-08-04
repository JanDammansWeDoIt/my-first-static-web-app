using FluentValidation;
using LanguageExt.Common;
using Newtonsoft.Json.Linq;
using WedoIT.NextGen.Data.Repositories.BlockRepository;
using WedoIT.NextGen.Data.Repositories.PersonRepository;
using WedoIT.NextGen.Data.Repositories.ProjectRepository;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.CodeRepositoryService;
using WedoIT.NextGen.Service.Validators;

namespace WedoIT.NextGen.Service.Services.ProjectService;

public class ProjectService : IProjectService
{
    private readonly IBlockRepository _blockRepository;
    private readonly ICodeRepositoryService _codeRepositoryService;
    private readonly IPersonRepository _personRepository;
    private readonly IProjectRepository _projectRepository;
    protected CreateProjectValidator createProjectValidator;

    public ProjectService(ICodeRepositoryService codeRepositoryService, IProjectRepository projectRepository,
        IPersonRepository personRepository,
        IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
        _personRepository = personRepository;
        _projectRepository = projectRepository;
        _codeRepositoryService = codeRepositoryService;
        createProjectValidator = new CreateProjectValidator(_projectRepository, _personRepository, _blockRepository);
    }

    public async Task<Result<Project>> CreateProject(Project project)
    {
        var validationResult = await createProjectValidator.ValidateAsync(project);
        if (!validationResult.IsValid)
        {
            var validationException = new ValidationException(validationResult.Errors);
            return new Result<Project>(validationException);
        }

        var resultProject = await _projectRepository.Add(project);
        var projectName = project.Name.Replace(" ", "").ToLower();
        foreach (var typeApp in project.Types)
        {
            var resultCodeRepository =
                await _codeRepositoryService.CreateRepository(projectName, typeApp);
            var resultJson = JObject.Parse(await resultCodeRepository.Content.ReadAsStringAsync());
            var url = resultJson.Property("url")?.Value.ToString();

            if (url is not null)
            {
                if (!string.IsNullOrEmpty(project.RepositoryUrl))
                    project.RepositoryUrl += ";";

                project.RepositoryUrl += url;
                await _projectRepository.UpdateRepositoryUrl(project.Id, url);
            }
        }


        return new Result<Project>(resultProject);
    }

    public async Task<List<Project>> GetAllProjects() => await _projectRepository.GetAll();
}