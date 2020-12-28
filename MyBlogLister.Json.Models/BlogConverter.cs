using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyBlogLister.Json.Models
{
    internal static class BlogConverter
    {
        public static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles =
                            DateTimeStyles.AssumeUniversal
                    }
                }
            };
    }
}