using RESTfulAPIConsume.Model;
using RestSharp;
using System.Collections.Generic;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class RestSharpRequestHandler : IRequestHandler
    {
        public string GetReleases(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute(new RestRequest());

            return response.Content;
        }

        //Alternative way, using RestSharp's parser
        public List<GitHubRelease> GetDeserializedReleases(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<List<GitHubRelease>>(new RestRequest());

            return response.Data;
        }
    }
}
