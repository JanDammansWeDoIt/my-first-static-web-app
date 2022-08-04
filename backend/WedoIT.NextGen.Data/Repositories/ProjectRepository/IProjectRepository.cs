using WedoIT.NextGen.Data.Repositories.BaseRepository;
using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Data.Repositories.ProjectRepository;

public interface IProjectRepository
{
    public Task<Project> Add(Project project);
    public Task<bool> UpdateRepositoryUrl(Guid projectId, string repositoryUrl);
    public Task<List<Project>> GetAll();
    public Task<Project?> GetProjectByFullNameAndCreatorId(string projectName, Guid creatorId);
}