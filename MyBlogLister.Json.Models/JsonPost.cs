using Newtonsoft.Json;

namespace MyBlogLister.Json.Models
{
    public class JsonPost
    {
        [JsonProperty("content")] public string Content { get; set; }
        [JsonProperty("date")] public string Date { get; set; }
        [JsonProperty("permalink")] public string Permalink { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
    }
}