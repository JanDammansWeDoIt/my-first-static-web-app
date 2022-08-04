using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Shouldly;
using ProjectModel = WedoIT.NextGen.Domain.DomainModels.Project;
using ProjectEntity = WedoIT.NextGen.Data.Entities.Project;
using WedoIT.NextGen.Data.Repositories.BlockRepository;
using WedoIT.NextGen.Data.Repositories.PersonRepository;
using WedoIT.NextGen.Data.Repositories.ProjectRepository;
using WedoIT.NextGen.Domain.DomainModels;
using WedoIT.NextGen.Service.Validators;
using Xunit;

namespace WedoIT.NextGen.Tests.ServiceLayer.ValidatorTests;

public class CreateProjectValidatorTests
{
    private readonly IProjectRepository _mockedProjectRepository;
    private readonly IBlockRepository _mockedBlockRepository;
    private readonly IPersonRepository _mockedPersonRepository;
    private readonly CreateProjectValidator _createProjectValidator;
    private readonly ProjectModel _testModel;
    private readonly Block _testBlock;

    // Setup
    public CreateProjectValidatorTests()
    {
        _testBlock = new Block()
        {
            Id = Guid.Parse("be9ebf9e-0553-44e4-aef6-fc1187217e30"),
            Command = "dotnet install",
            IsDeleted = false,
            Name = "TestBlock"
        };
        _testModel = new ProjectModel
        {
            Id = new Guid("1F017306-F53B-42C9-AB21-7FDA74233605"),
            Domain = "",
            Name = "TestProjectName",
            Types = new List<string>(){"WebApplication"},
            CreatedAt = DateTime.Now,
            CreatorId =  Guid.Parse("608c221a-2964-4eea-93f1-4c64f8c75ed8"),
            ClientName = "TestClientName",
            HasDatabase = false,
            NeedHosting = false,
            RepositoryUrl = "",
            LastModified = DateTime.Now,
            Blocks = new List<Block>(){_testBlock}
        };
        
        _mockedBlockRepository = Substitute.For<IBlockRepository>();
        _mockedPersonRepository = Substitute.For<IPersonRepository>();
        _mockedProjectRepository = Substitute.For<IProjectRepository>();
        _createProjectValidator = new CreateProjectValidator(_mockedProjectRepository,_mockedPersonRepository,_mockedBlockRepository);
    }
    
    [Fact]
    public async void CreateProject_ProjectNameAlreadyExistsForClient_ShouldReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-93f1-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name,_testModel.CreatorId)!
            .Returns(_testModel);
        _mockedPersonRepository
            .GetPersonById(Guid.Parse("608c221a-2964-4eea-93f1-4c64f8c75ed8"))
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock});
        
        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.ErrorMessage == "Project name already exists for the client");
    }
    
    [Fact]
    public async void CreateProject_ProjectNameAlreadyExistsButNoForClient_ShouldNotReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-aaaa-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId("TestProjectName", new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(Arg.Any<Guid>())
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldBeEmpty();
        result.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public async void CreateProject_ProjectNameIsEmpty_ShouldReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-aaaa-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _testModel.Name = "";
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name, new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(_testModel.CreatorId)
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.ErrorMessage == "Project name cannot be empty");
    }
    
    [Fact]
    public async void CreateProject_TypesIsEmpty_ShouldReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-aaaa-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _testModel.Types = new List<string>();
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name, new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(_testModel.CreatorId)
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x 
            => x.ErrorMessage == "At least 1 type of application is required");
    }

    [Fact]
    public async void CreateProject_CreatorDoesNotExists_ShouldReturnError()
    {
        // Arrange
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name, new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(_testModel.CreatorId)
            .Returns(null as Person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x 
            => x.ErrorMessage == "CreatorId doesn't exists");
    }

    [Fact]
    public async void CreateProject_BlocksDoesNotExists_ShouldReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-aaaa-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name, new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(_testModel.CreatorId)
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock,_testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x 
            => x.ErrorMessage == "Blocks does not exists");
    }
    
    [Fact]
    public async void CreateProject_BlocksAreEmpty_ShouldReturnError()
    {
        // Arrange
        var person = new Person()
        {
            Id = Guid.Parse("608c221a-2964-4eea-aaaa-4c64f8c75ed8"),
            Nickname = "Tester"
        };
        _testModel.Blocks = new List<Block>();
        _mockedProjectRepository
            .GetProjectByFullNameAndCreatorId(_testModel.Name, new Guid("608c221a-2964-4eea-aaaa-4c64f8c75ed8"))
            .Returns(null as ProjectModel);
        _mockedPersonRepository
            .GetPersonById(_testModel.CreatorId)
            .Returns(person);
        _mockedBlockRepository
            .GetBlocksByListIds(Arg.Any<List<Guid>>())
            .Returns(new List<Block>(){_testBlock, _testBlock});

        // Act
        var result = await _createProjectValidator.ValidateAsync(_testModel);
       
        // Assert
        result.Errors.ShouldNotBeEmpty();
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x 
            => x.ErrorMessage == "Blocks are required");
    }

}