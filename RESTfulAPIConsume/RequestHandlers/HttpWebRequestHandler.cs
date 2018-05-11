using Newtonsoft.Json.Linq;
using RESTfulAPIConsume.Constants;
using System.IO;
using System.Net;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpWebRequestHandler : IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = RequestConstants.UserAgent;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            return JArray.Parse(content);
        }
    }
}
