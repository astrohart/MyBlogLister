using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlogLister.Json.Models
{
    public class JsonBlog
    {
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("date")] public string Date { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("permalink")] public string Permalink { get; set; }
        [JsonProperty("posts")] public List<JsonPost> Posts { get; set; }
    }
}