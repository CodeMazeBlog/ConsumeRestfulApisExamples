using DalSoft.RestClient;
using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTfulAPIConsume.RequestHandlers
{
    class DalSoftRequestHandler : IRequestHandler
    {
        public string GetReleases(string url)
        {
            var defaultHeaders = new Dictionary<string, string>
            {
                { RequestConstants.UserAgent, RequestConstants.UserAgentValue }
            };

            dynamic client = new RestClient("https://api.github.com", defaultHeaders);
            
            var response = client.repos.restsharp.restsharp.releases.Get().Result.ToString();

            return response;
        }

        //Here's a great way to deserialize the response "organically"
        public async Task<List<GitHubRelease>> GetDeserializedReleases(string url)
        {
            var defaultHeaders = new Dictionary<string, string>
            {
                { RequestConstants.UserAgent, RequestConstants.UserAgentValue }
            };

            dynamic client = new RestClient("https://api.github.com", defaultHeaders);

            var response = await client.repos.restsharp.restsharp.releases.Get();

            return response;
        }
    }
}
