using AutoMapper;
using WedoIT.NextGen.Api.Endpoints.Projects;
using WedoIT.NextGen.Api.Endpoints.Projects.Create;
using WedoIT.NextGen.Api.Endpoints.Projects.List;
using WedoIT.NextGen.Api.Endpoints.Responses;
using WedoIT.NextGen.Data.Entities;
using BlockEntity = WedoIT.NextGen.Data.Entities.Block;
using ProjectEntity = WedoIT.NextGen.Data.Entities.Project;
using CreatorEntity = WedoIT.NextGen.Data.Entities.Person;
using PersonEntity = WedoIT.NextGen.Data.Entities.Person;
using PersonModel = WedoIT.NextGen.Domain.DomainModels.Person;
using BlockModel = WedoIT.NextGen.Domain.DomainModels.Block;
using ProjectModel = WedoIT.NextGen.Domain.DomainModels.Project;
using CreatorModel = WedoIT.NextGen.Domain.DomainModels.Person;
namespace WedoIT.NextGen.Api.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProjectEntity, ProjectModel>()
            .ForMember(x => x.Types, opt => opt.Ignore())
            .ForMember(x => x.Blocks, opt => opt.Ignore());
        CreateMap<ProjectModel, ProjectEntity>()
            .ForMember(x => x.ProjectBlocks, opt => opt.Ignore());
        CreateMap<ProjectModel, CreateProjectResponse>();
        CreateMap<ProjectBlock, BlockModel>()
            .ForMember(x => x.Name, p => p.MapFrom(block => block.Block.Name))
            .ForMember(x => x.Command, p => p.MapFrom(block => block.Block.Command))
            .ForMember(x=>x.IsDeleted, p=>p.MapFrom(block=>block.Block.IsDeleted))
            .ForMember(x => x.Id, p => p.MapFrom(block => block.Block.Id));
        CreateMap<ProjectModel, ListProjectResponse>();
        CreateMap<BlockEntity, BlockModel>().ReverseMap();
        CreateMap<PersonModel, PersonEntity>().ReverseMap();
        CreateMap<CreatorEntity, CreatorModel>().ReverseMap();
        CreateMap<BlockModel, BlockResponse>().ReverseMap();
        CreateMap<ProjectRequest, ProjectModel>()
            .ForMember(request => request.Blocks, expression => expression.Ignore())
            .BeforeMap((request, project) => project.Status = "Pending")
            .ForMember(project => project.Status, expression => expression.Ignore())
            .ForMember(project => project.Id, expression => expression.Ignore())
            .ForMember(project => project.Histories, expression => expression.Ignore())
            .BeforeMap((request, project) => project.IsDeleted = false)
            .ForMember(project => project.IsDeleted, expression => expression.Ignore())
            .BeforeMap((request, project) => project.Creator = null!)
            .ForMember(project => project.Creator, expression => expression.Ignore());
    }
}