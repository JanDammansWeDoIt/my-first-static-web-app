using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using WedoIT.NextGen.Api.Mapper;
using WedoIT.NextGen.Data.Repositories.BlockRepository;
using WedoIT.NextGen.Data.Repositories.PersonRepository;
using WedoIT.NextGen.Data.Repositories.ProjectRepository;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Services.CodeRepositoryService;
using WedoIT.NextGen.Service.Services.ProjectService;
using Xunit;

namespace WedoIT.NextGen.Tests.ServiceLayer.ServicesTests;

[ExcludeFromCodeCoverage]
public class ProjectServiceTests
{
    private readonly ILogger<ProjectService> _logger;

    private readonly IMapper _mapper;
    private readonly IBlockRepository _mockedBlockRepository;
    private readonly ICodeRepositoryService _mockedCodeRepositoryService;
    private readonly IPersonRepository _mockedPersonRepository;
    private readonly IProjectRepository _mockedProjectRepository;
    private readonly IProjectService _service;
    private readonly Project _testEntity;
    private readonly Project _testModel;

    // Setup
    public ProjectServiceTests()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
        _testModel = new Project
        {
            Id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605"),
            Domain = "",
            Name = "",
            Types = new List<string>(),
            CreatedAt = DateTime.Now,
            CreatorId = default,
            ClientName = "",
            HasDatabase = false,
            NeedHosting = false,
            RepositoryUrl = "",
            LastModified = DateTime.Now
        };
        _mockedProjectRepository = Substitute.For<IProjectRepository>();
        _mockedBlockRepository = Substitute.For<IBlockRepository>();
        _mockedPersonRepository = Substitute.For<IPersonRepository>();
        _mockedCodeRepositoryService = Substitute.For<ICodeRepositoryService>();
        _logger = Substitute.For<ILogger<ProjectService>>();
        _mapper = Substitute.For<IMapper>();
        _service = new ProjectService(_mockedCodeRepositoryService, _mockedProjectRepository, _mockedPersonRepository,
            _mockedBlockRepository);
    }


    [Fact]
    public async void Create_ServiceHasBeenCalled()
    {
        // Arrange
        var newProject = new Project
        {
            Id = Guid.NewGuid(),
            Domain = "",
            Name = "",
            Types = new List<string>(),
            CreatedAt = new DateTime(),
            CreatorId = new Guid(),
            ClientName = "",
            HasDatabase = true,
            NeedHosting = true,
            RepositoryUrl = "",
            LastModified = new DateTime()
        };

        // Act

        // Assert
    }

    [Fact]
    public async void GetAll_ReturnsOk()
    {
        // Arrange
        var models = new List<Project> { _testModel, _testModel, _testModel };
        _mockedProjectRepository.GetAll().Returns(models);
        _mapper.Map<ICollection<Project>>(models)
            .Returns(models);
        var response = models;
        // Act
        var result = await _service.GetAllProjects();
        var expected = JsonConvert.SerializeObject(response);
        var actual = JsonConvert.SerializeObject(result);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async void GetAll_ServiceHasBeenCanceled()
    {
        // Arrange
        _service.GetAllProjects().Throws<Exception>();

        //Act
        // Assert
        await Assert.ThrowsAsync<Exception>(async () => await _service.GetAllProjects());
    }
}