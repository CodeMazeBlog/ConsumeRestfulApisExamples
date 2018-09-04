using Newtonsoft.Json.Linq;
using RESTfulAPIConsume.Constants;
using System.Net;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class WebClientRequestHandler: IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            var client = new WebClient();
            client.Headers.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

            var response = client.DownloadString(url);

            var content = JArray.Parse(response);

            return content;
        }
    }
}
