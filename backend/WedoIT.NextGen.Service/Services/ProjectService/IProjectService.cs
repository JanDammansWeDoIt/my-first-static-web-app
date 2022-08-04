using LanguageExt.Common;
using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Service.Services.ProjectService;

public interface IProjectService
{
    public Task<Result<Project>> CreateProject(Project project);

    Task<List<Project>> GetAllProjects();
}