using Newtonsoft.Json.Linq;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.RequestHandlers;
using System;

namespace RESTfulAPIConsume
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching the list of RestSharp releases and their publish dates.");
            Console.WriteLine();

            //These are the five ways to consume RESTful APIs described in the blog post
            IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();
            IRequestHandler webClientRequestHandler = new WebClientRequestHandler();
            IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();
            IRequestHandler restSharpRequestHandler = new RestSharpRequestHandler();
            IRequestHandler serviceStackRequestHandler = new ServiceStackRequestHandler();

            //Currently HttpWebRequest is used to get the RestSharp releases
            //Replace the httpWebRequestHandler variable with one of the above to test out different libraries
            //Results should be the same
            var releases = GetReleases(serviceStackRequestHandler);

            //List out the retreived releases
            foreach (JObject release in releases.Children())
            {
                Console.WriteLine("Release: {0}", release.GetValue("name"));
                Console.WriteLine("Published: {0}", DateTime.Parse(release.GetValue("published_at").ToString()));
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static JToken GetReleases(IRequestHandler requestHandler)
        {
            return requestHandler.GetReleases(RequestConstants.Url);
        }
    }
}
