using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using RESTfulAPIConsume.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Net;

namespace RESTfulAPIConsume
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching the list of RestSharp releases and their publish dates.");
            Console.WriteLine();

            //These are the ways to consume RESTful APIs as described in the blog post
            IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();
            IRequestHandler webClientRequestHandler = new WebClientRequestHandler();
            IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();
            IRequestHandler restSharpRequestHandler = new RestSharpRequestHandler();
            IRequestHandler serviceStackRequestHandler = new ServiceStackRequestHandler();
            IRequestHandler flurlRequestHandler = new FlurlRequestHandler();
            IRequestHandler dalSoftRequestHandler = new DalSoftRequestHandler();

            //to support github's depreciation of older cryptographic standards (might be useful for some other APIs too)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //By default HttpWebRequest is used to get the RestSharp releases
            //Replace the httpWebRequestHandler variable with one of the above to test out different libraries
            //Results should be the same
            var response = GetReleases(httpWebRequestHandler);

            var githubReleases = JsonConvert.DeserializeObject<List<GitHubRelease>>(response);

            foreach (var release in githubReleases)
            {
                Console.WriteLine("Release: {0}", release.Name);
                Console.WriteLine("Published: {0}", DateTime.Parse(release.PublishedAt));
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static string GetReleases(IRequestHandler requestHandler)
        {
            return requestHandler.GetReleases(RequestConstants.Url);
        }
    }
}
