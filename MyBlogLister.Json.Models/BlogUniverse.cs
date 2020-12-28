using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBlogLister.Json.Models
{
    public class BlogUniverse
    {
        [JsonProperty("blogs")] public List<JsonBlog> Blogs { get; set; }
    }
}