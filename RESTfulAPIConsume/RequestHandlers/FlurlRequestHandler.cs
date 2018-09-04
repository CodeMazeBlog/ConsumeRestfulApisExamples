using Flurl.Http;
using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using System.Collections.Generic;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class FlurlRequestHandler: IRequestHandler
    {
        public string GetReleases(string url)
        {
            var result = url
                            .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                            .GetJsonAsync<List<GitHubRelease>>()
                            .Result;

            return JsonConvert.SerializeObject(result);// a really bad way to do things, but for demonstration purposes it will do
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
