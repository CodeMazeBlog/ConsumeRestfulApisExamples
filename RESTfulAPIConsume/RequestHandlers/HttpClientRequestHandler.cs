using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpClientRequestHandler: IRequestHandler
    {
        public JToken GetReleases(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                return JArray.Parse(response);
            }
        }
    }
}
