namespace WedoIT.NextGen.Service.Services.CodeRepositoryService;

public interface ICodeRepositoryService
{
    public Task<HttpResponseMessage> CreateRepository(string projectname, string typeApp);
}