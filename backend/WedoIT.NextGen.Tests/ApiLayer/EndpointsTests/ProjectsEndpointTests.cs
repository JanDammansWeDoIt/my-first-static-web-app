using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using WedoIT.NextGen.Api.Endpoints.Projects;
using WedoIT.NextGen.Api.Endpoints.Projects.Create;
using WedoIT.NextGen.Api.Endpoints.Projects.List;
using WedoIT.NextGen.Api.Endpoints.Responses;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.ProjectService;
using Xunit;

namespace WedoIT.NextGen.Tests.ApiLayer.EndpointsTests;

[ExcludeFromCodeCoverage]
public class ProjectsEndpointTests
{
    private readonly ListProjectResponse _listProjectsResponse;
    private readonly IMapper _mapper;
    private readonly IProjectService _service;
    private readonly Project _testEntity;
    private readonly Project _testModel;
    private readonly ProjectRequest _testRequest;

    // Setup
    public ProjectsEndpointTests()
    {
        _service = Substitute.For<IProjectService>();
        _mapper = Substitute.For<IMapper>();
        _testEntity = new Project
        {
            Id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605"),
            Domain = "",
            Name = "",
            Types = new List<string>(),
            CreatedAt = new DateTime(),
            CreatorId = new Guid(),
            ClientName = "",
            HasDatabase = true,
            NeedHosting = true,
            RepositoryUrl = "",
            LastModified = new DateTime(),
        };
        _testModel = new Project
        {
            Id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605"),
            Domain = "",
            Name = "",
            Types = new List<string>(),
            CreatedAt = new DateTime(),
            CreatorId = new Guid(),
            ClientName = "",
            HasDatabase = true,
            NeedHosting = true,
            RepositoryUrl = "",
            LastModified = new DateTime(),
        };
        _testRequest = new ProjectRequest
        {
            Domain = "",
            Name = "",
            Types = new List<string>(),
            CreatedAt = new DateTime(),
            CreatorId = new Guid(),
            ClientName = "",
            HasDatabase = true,
            NeedHosting = true,
            RepositoryUrl = "",
            LastModified = new DateTime(),
        };
    }


    [Fact]
    public async void Create_ReturnCreated()
    {
        // Arrange
        _service.CreateProject(_testModel).Returns(_testModel);
        _mapper.Map<Project, Project>(_testEntity).Returns(_testModel);
        _mapper.Map<ProjectRequest, Project>(_testRequest).Returns(_testModel);

        // Act
        var result = await CreateEndpoint.InvokeAsync(_testRequest, _service, _mapper);

        // Assert

        // Assert.Equal(3, result.val);
    }

    [Fact]
    public async void GetAll_ProjectsHasBlocks_ReturnOK()
    {
        // Arrange
        var modelWithBlocks = _testModel;
        modelWithBlocks.Blocks = new List<Block>()
        {
            new Block()
            {
                Name = "Login",
                Command = "dotnet d",
                Id = Guid.NewGuid()
            },
            new Block()
            {
                Name = "Login",
                Command = "dotnet d",
                Id = Guid.NewGuid()
            }
        };
        List<Project> models = new List<Project>
        {
            modelWithBlocks,
            modelWithBlocks,
            modelWithBlocks
        };
        List<BlockResponse> blockResponses = new List<BlockResponse>
        {
            new BlockResponse()
            {
                Name = "Login",
                Command = "dotnet d"
            },  new BlockResponse()
            {
                Name = "Login",
                Command = "dotnet d"
            },  new BlockResponse()
            {
                Name = "Login",
                Command = "dotnet d"
            }
        };
     
        var response = new List<ListProjectResponse>()
        {
            new ListProjectResponse()
            {
                Blocks = blockResponses
            },
            new ListProjectResponse()
            {
                Blocks = blockResponses
            },
            new ListProjectResponse()
            {
                Blocks = blockResponses
            }
        };
        _service.GetAllProjects().Returns(models);
        _mapper.Map<List<Project>, List<ListProjectResponse>>(models).Returns(response);
        
        // Act
        var result = await ListEndpoint.InvokeAsync(_service, _mapper);

        // Assert
        var expected = JsonConvert.SerializeObject(Results.Ok(response));
        var actual = JsonConvert.SerializeObject(result);
        Assert.Equal(expected, actual);
    }

      
      [Fact]
    public async void GetAll_ActionFailed_ReturnException()
    {
        // Arrange
        _service.GetAllProjects().Throws<Exception>();

        //Act
        // Assert
        await Assert.ThrowsAsync<Exception>(async () => await _service.GetAllProjects());
    }


    [Fact]
    public async void GetById_IfEntityIsFound_ReturnOK()
    {
        // // Arrange
        // var id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605");
        // // _service.GetById(id).Returns(_testEntity);
        // _mapper.Map<Project, ProjectResponse>(_testEntity).Returns(_testResponse);
        //
        // // Act
        // // var result = await GetEndpoint.InvokeAsync(id, _service, _mapper);
        //
        // // Assert
        // var expected = JsonConvert.SerializeObject(Results.Ok(_testResponse));
        // // var actual = JsonConvert.SerializeObject(result);
        // // Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetById_IfEntityIsNotFound_ReturnNotFound()
    {
        // Arrange
        // var id = Guid.NewGuid();
        //
        // // Act
        // // var result = await GetEndpoint.InvokeAsync(id, _service, _mapper);
        //
        // // Assert
        // var expected = JsonConvert.SerializeObject(Results.NotFound());
        // // var actual = JsonConvert.SerializeObject(result);
        // // Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetById_IfEntityIsSoftDeleted_ReturnNotFound()
    {
        // Arrange
        // var id = Guid.NewGuid();
        // _testEntity.IsDeleted = true;
        // // _service.GetById(id).Returns(_testEntity);
        //
        // // Act
        // // var result = await GetEndpoint.InvokeAsync(id, _service, _mapper);
        //
        // // Assert
        // var expected = JsonConvert.SerializeObject(Results.NotFound());
        // // var actual = JsonConvert.SerializeObject(result);
        // // Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetById_ProjectHasFunctionalities_ReturnProjectWithProjectFunctionalities()
    {
        // // Arrange
        // var id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605");
        // _testEntity.ProjectFunctionalities = new List<ProjectFunctionality>
        // {
        //     new()
        //     {
        //         Id = new Guid(),
        //         IsDeleted = false,
        //         FunctionalityId = default,
        //         Functionality = null,
        //         ProjectId = default,
        //         Project = null
        //     },
        //     new()
        //     {
        //         Id = new Guid(),
        //         IsDeleted = false,
        //         FunctionalityId = default,
        //         Functionality = null,
        //         ProjectId = default,
        //         Project = null
        //     }
        // };
        // _testResponse.ProjectFunctionalities = new List<ProjectFunctionalityResponse>
        // {
        //     new()
        //     {
        //         Id = new Guid(),
        //         FunctionalityId = default,
        //         Functionality = null,
        //         ProjectId = default,
        //         Project = null
        //     },
        //     new()
        //     {
        //         Id = new Guid(),
        //         FunctionalityId = default,
        //         Functionality = null,
        //         ProjectId = default,
        //         Project = null
        //     }
        // };
        // _service.GetById(id).Returns(_testEntity);
        // _mapper.Map<Project, ProjectResponse>(_testEntity).Returns(_testResponse);
        //
        // // Act
        // var result = await GetEndpoint.InvokeAsync(id, _service, _mapper);
        //
        // // Assert
        // var expected = JsonConvert.SerializeObject(Results.Ok(_testResponse));
        // var actual = JsonConvert.SerializeObject(result);
        // Assert.Equal(expected, actual);
    }
}