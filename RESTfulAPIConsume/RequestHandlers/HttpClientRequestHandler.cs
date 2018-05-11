using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpClientRequestHandler: IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");

                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                
                return JArray.Parse(response);
            }
        }
    }
}
