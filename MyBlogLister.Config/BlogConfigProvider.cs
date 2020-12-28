using System.Collections.Generic;
using MyBlogLister.Interfaces;

namespace MyBlogLister.Config
{
    public static class BlogConfigProvider
    {
        public static IBlogConfigBackend Backend { get; set; }
        public static IEnumerable<IBlogDto> Blogs => Backend.Blogs;
    }
}