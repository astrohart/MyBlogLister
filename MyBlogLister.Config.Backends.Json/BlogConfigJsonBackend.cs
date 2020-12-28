using System;
using System.Collections.Generic;
using MyBlogLister.Interfaces;

namespace MyBlogLister.Config.Backends.Json
{
    public class BlogConfigJsonBackend : IBlogConfigBackend
    {
        /// <summary>Constructs a new instance of <see cref="T:MyBlogLister.Config.Backends.Json.BlogConfigJsonBackend" /> and returns a reference to it.</summary>
        public BlogConfigJsonBackend()
        {
            Blogs = new List<IBlog>();
        }

        public IEnumerable<IBlog> Blogs { get; }

        public IEnumerable<IBlog> Load(dynamic dataSourceName) =>
            throw new NotImplementedException();

        public void Save(dynamic dataSourceName, IEnumerable<IBlog> data) =>
            throw new NotImplementedException();
    }
}