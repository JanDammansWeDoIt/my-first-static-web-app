using FluentValidation;
using WedoIT.NextGen.Data.Repositories.BlockRepository;
using WedoIT.NextGen.Data.Repositories.PersonRepository;
using WedoIT.NextGen.Data.Repositories.ProjectRepository;
using WedoIT.NextGen.Domain.DomainModels;

namespace WedoIT.NextGen.Service.Validators;

public class CreateProjectValidator : AbstractValidator<Project>
{
    private readonly IBlockRepository _blockRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IProjectRepository _projectRepository;

    public CreateProjectValidator(IProjectRepository projectRepository, IPersonRepository personRepository,
        IBlockRepository blockRepository)
    {
        _blockRepository = blockRepository;
        _personRepository = personRepository;
        _projectRepository = projectRepository;

        RuleLevelCascadeMode = CascadeMode.Continue;

        RuleFor(project => project.Name).NotEmpty().WithMessage("Project name cannot be empty");
        RuleFor(project => project.ClientName).NotEmpty().WithMessage("Client name cannot be empty");
        RuleFor(project => project.Types).NotEmpty().WithMessage("At least 1 type of application is required");
        RuleFor(project => project.Types).Must(IsAllowedType).WithMessage("No allowed type of application");
        RuleFor(project => project.CreatorId).Must(CreatorExistst).WithMessage("CreatorId doesn't exists");
        RuleFor(project => project.Blocks).Must(BlocksExists).WithMessage("Blocks does not exists");

        RuleFor(project => project.Name).Must((project, notused)
            =>
        {
            return IsProjectNameUnique(project.Name, project.CreatorId);
        }).WithMessage("Project name already exists for the client");
    }

    public bool IsAllowedType(List<string> types)
    {
        var result =
            types.FirstOrDefault(type
                => type != "Web Application" && type != "Website" && type != "Mobile Application");
        return result == null;
    }

    public bool IsProjectNameUnique(string projectName, Guid creatorId)
    {
        var result = _projectRepository.GetProjectByFullNameAndCreatorId(projectName, creatorId).Result;
        return result == null;
    }

    public bool CreatorExistst(Guid creatorId)
    {
        var result = _personRepository.GetPersonById(creatorId).Result;
        return result is not null;
    }

    public bool BlocksExists(List<Block> blocks)
    {
        var result =
            _blockRepository.GetBlocksByListIds(
                blocks.Select(block => block.Id).ToList()
            ).Result;
        return result.Count == blocks.Count;
    }
}