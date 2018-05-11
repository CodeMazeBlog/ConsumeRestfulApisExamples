using System.Net;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class BaseRequestHandler
    {
        public BaseRequestHandler()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
