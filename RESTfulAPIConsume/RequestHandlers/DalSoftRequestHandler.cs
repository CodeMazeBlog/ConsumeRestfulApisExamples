using DalSoft.RestClient;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfulAPIConsume.RequestHandlers
{
    class DalSoftRequestHandler : IRequestHandler
    {
        public string GetReleases(string url)
        {
            dynamic client = new RestClient(RequestConstants.BaseUrl, 
                new Dictionary<string, string> { { RequestConstants.UserAgent, RequestConstants.UserAgentValue } });
            
            var response = client.repos.restsharp.restsharp.releases.Get().Result.ToString();

            return response;
        }

        //Here's a great way to deserialize the response "organically"
        public async Task<List<GitHubRelease>> GetDeserializedReleases(string url)
        {
            dynamic client = new RestClient(RequestConstants.BaseUrl, 
                new Dictionary<string, string> { { RequestConstants.UserAgent, RequestConstants.UserAgentValue } });

            var response = await client.repos.restsharp.restsharp.releases.Get();

            return response;
        }
    }
}
