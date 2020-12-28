using Newtonsoft.Json;

namespace MyBlogLister.Json.Models
{
    public static class BlogSerializer
    {
        public static BlogUniverse FromJson(string json) =>
            JsonConvert.DeserializeObject<BlogUniverse>(
                json, BlogConverter.Settings
            );

        public static string ToJson(this BlogUniverse self) =>
            JsonConvert.SerializeObject(self, BlogConverter.Settings);
    }
}