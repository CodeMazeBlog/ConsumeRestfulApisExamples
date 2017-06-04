using Newtonsoft.Json.Linq;

namespace RESTfulAPIConsume.RequestHandlers
{
    public interface IRequestHandler
    {
        //Method to get the releases of the repo provided by the url
        //We will be using RestSharp repo as an example (defined in constants)
        JToken GetReleases(string url);
    }
}
