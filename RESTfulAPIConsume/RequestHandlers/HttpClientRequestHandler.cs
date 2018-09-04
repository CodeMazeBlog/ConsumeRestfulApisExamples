using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using RESTfulAPIConsume.Constants;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpClientRequestHandler: IRequestHandler
    {
        public string GetReleases(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                return response;
            }
        }
    }
}
