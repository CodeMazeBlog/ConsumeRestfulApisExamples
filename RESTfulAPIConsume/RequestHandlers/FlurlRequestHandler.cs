using Flurl.Http;
using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class FlurlRequestHandler: IRequestHandler
    {
        // A really bad way to do things, but for demonstration purposes it will do
        // Flurl has it's own deserializer so it's better to do it like demonstrated in GetDeserializedReleases method
        public string GetReleases(string url)
        {
            var result = url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .GetJsonAsync<List<GitHubRelease>>()
                .Result;

            return JsonConvert.SerializeObject(result);
        }

        public List<GitHubRelease> GetDeserializedReleases(string url)
        {
            var result = url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .GetJsonAsync<List<GitHubRelease>>()
                .Result;

            return result;
        }
    }
}
