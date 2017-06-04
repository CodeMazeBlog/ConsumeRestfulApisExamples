using RestSharp.Deserializers;

namespace RESTfulAPIConsume.Model
{
    public class GitHubRelease
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
        [DeserializeAs(Name = "published_at")]
        public string PublishedAt { get; set; }
    }
}
