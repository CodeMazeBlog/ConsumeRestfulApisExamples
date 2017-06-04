using Newtonsoft.Json.Linq;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using ServiceStack;
using System.Collections.Generic;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class ServiceStackRequestHandler: IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            var response = url.GetJsonFromUrl(requestFilter: webReq =>
            {
                webReq.UserAgent = RequestConstants.UserAgent;
            });

            return JArray.Parse(response);
        }

        //Alternative way, using ServiceStack's parser
        public List<GitHubRelease> GetDeserializedReleases(string url)
        {
            List<GitHubRelease> releases = url.GetJsonFromUrl(requestFilter: webReq =>
            {
                webReq.UserAgent = RequestConstants.UserAgent;
            }).FromJson<List<GitHubRelease>>();

            return releases;
        }
    }
}
