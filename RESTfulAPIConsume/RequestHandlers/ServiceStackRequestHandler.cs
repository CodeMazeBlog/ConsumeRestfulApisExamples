using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using ServiceStack;
using System.Collections.Generic;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class ServiceStackRequestHandler: IRequestHandler
    {
        public string GetReleases(string url)
        {
            var response = url.GetJsonFromUrl(webReq =>
            {
                webReq.UserAgent = RequestConstants.UserAgentValue;
            });

            return response;
        }

        //Alternative way, using ServiceStack's parser
        public List<GitHubRelease> GetDeserializedReleases(string url)
        {
            var releases = url.GetJsonFromUrl(webReq =>
            {
                webReq.UserAgent = RequestConstants.UserAgentValue;
            }).FromJson<List<GitHubRelease>>();

            return releases;
        }
    }
}
