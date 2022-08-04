using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WedoIT.NextGen.Data.Context;
using WedoIT.NextGen.Data.Entities;
using WedoIT.NextGen.Data.Repositories.BaseRepository;
using WedoIT.NextGen.Domain.DomainModels;
using ProjectEntity = WedoIT.NextGen.Data.Entities.Project;
using BlockEntity = WedoIT.NextGen.Data.Entities.Block;
using ProjectModel = WedoIT.NextGen.Domain.DomainModels.Project;
using BlockModel = WedoIT.NextGen.Domain.DomainModels.Block;

namespace WedoIT.NextGen.Data.Repositories.ProjectRepository;

public class ProjectRepository : BaseRespository, IProjectRepository
{
    public ProjectRepository(NextGenDbContext context, IMapper mapper, ILogger<BaseDomainModel> logger) : base(context, mapper, logger)
    {
    }

    public async Task<ProjectModel> Add(ProjectModel project)
    {
        var mappedProject = Mapper.Map<ProjectModel, ProjectEntity>(project);
        var types = new StringBuilder();
        for (var i = 0; i <= project.Types.Count - 1; i++)
        {
            types.Append(project.Types[i]);
            if (i != project.Types.Count - 1) types.Append(';');
        }

        mappedProject.Types = types.ToString();
        foreach (var block in project.Blocks)
        {
            mappedProject.ProjectBlocks.Add(new ProjectBlock() { ProjectId = project.Id, BlockId = block.Id });
        }

        try
        {
            await Context.AddAsync(mappedProject);
            await Context.SaveChangesAsync();
            return project;
        }
        catch (Exception e)
        {
            Logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateRepositoryUrl(Guid projectId, string repositoryUrl)
    {
       
        try
        {
            var projectEntity = await GetById(projectId);
            if (projectEntity is null) return false;
            projectEntity.RepositoryUrl = repositoryUrl;
            Context.Update(projectEntity);
            await Context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Logger.LogError("{Message}", e.Message);
            throw;
        }
    }

    public async Task<List<ProjectModel>> GetAll()
    {
        try
        {
            var result =
                await Context.Projects
                    .Include(project => project.Creator)
                    .Include(projblock => projblock.ProjectBlocks)
                    .ThenInclude(projblock => projblock.Block)
                    .ToListAsync();

            var mappedResult = Mapper.Map<List<ProjectEntity>, List<ProjectModel>>(result);


            foreach (var project in result)
            {
                var map = Mapper.Map<List<ProjectBlock>, List<BlockModel>>(project.ProjectBlocks);
                var mappedProject = mappedResult.Find(x => x.Id == project.Id);
                if (mappedProject is not null) mappedProject.Blocks = map;
                if (!project.Types.Contains(';')) continue;
                var split = project.Types.Split(";");
                if (mappedProject != null) mappedProject.Types = split.ToList();
            }
            return mappedResult;
        }
        catch (Exception e)
        {
            Logger.LogError("{Message}", e.Message);
            throw;
        }
    }
    
    public async Task<ProjectModel?> GetProjectByFullNameAndCreatorId(string projectName, Guid creatorId)
    {
        try
        {
            var result = await Context.Projects.Where(project => project.Name == projectName && project.CreatorId == creatorId).FirstOrDefaultAsync();

            if (result != null)
            {
                var mappedResult = Mapper.Map<ProjectEntity, ProjectModel>(result);
                return mappedResult;
            }
        }
        catch (Exception e)
        {
            Logger.LogError("{Message}", e.Message);
            throw;
        }
        return null;
    }

    public Task<ProjectEntity?> GetById(Guid id)
    {
        try
        {
            return Context.Set<ProjectEntity>()
                .Include(project => project.Creator)
                .Where(project => project.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            Logger.LogError("{Message}", e.Message);
            throw;
        }
    }
}