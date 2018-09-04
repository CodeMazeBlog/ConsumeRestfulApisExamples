using RESTfulAPIConsume.Constants;
using System.Net;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class WebClientRequestHandler: IRequestHandler
    {
        public string GetReleases(string url)
        {
            var client = new WebClient();
            client.Headers.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

            var response = client.DownloadString(url);

            return response;
        }
    }
}
