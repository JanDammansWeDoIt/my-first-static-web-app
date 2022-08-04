using System.Net.Http.Headers;

namespace WedoIT.NextGen.Service.Services.CodeRepositoryService;

public class CodeRepositoryService : ICodeRepositoryService
{
    private const string templateWebAppUrl = "https://api.github.com/repos/we-do-it/wdi-webapp-template/generate";
    private const string templateWebsiteUrl = "https://api.github.com/repos/we-do-it/wdi-webapp-template/generate";
    private const string templateMobileAppUrl = "https://api.github.com/repos/we-do-it/wdi-webapp-template/generate";
    private const string personalAccessToken = "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";

    public async Task<HttpResponseMessage> CreateRepository(string projectname, string typeApp)
    {
        HttpResponseMessage result;
        string activeUrl;
        string activeType;
        var request = new HttpRequestMessage();
        request.Method = HttpMethod.Post;
        activeUrl = typeApp switch
        {
            "Mobile Application" => templateMobileAppUrl,
            "Website" => templateWebsiteUrl,
            "Web Application" => templateWebAppUrl,
            _ => templateWebAppUrl
        };
        activeType = typeApp switch
        {
            "Mobile Application" => "mobapp",
            "Website" => "website",
            "Web Application" => "webapp",
            _ => "webapp"
        };

        request.RequestUri = new Uri(activeUrl);
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
        request.Headers.TryAddWithoutValidation("Authorization", $"token {personalAccessToken}");
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("notused", "1.0")); // User agent required to work
        request.Content =
            new StringContent(
                $"{{\"owner\":\"we-do-it\",\"name\":\"{projectname}-{activeType}\",\"description\":\"\",\"include_all_branches\":false,\"private\":true}}");
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

        using (var httpClient = new HttpClient())
        {
            result = await httpClient.SendAsync(request);
        }

        return result;
    }
}