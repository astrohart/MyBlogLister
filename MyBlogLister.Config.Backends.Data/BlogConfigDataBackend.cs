using System;
using System.Collections.Generic;
using System.Linq;
using MyBlogLister.BusinessLayer.BusinessLayer;
using MyBlogLister.DtoProvider;
using MyBlogLister.Interfaces;

namespace MyBlogLister.Config.Backends.Data
{
    public class BlogConfigDataBackend : IBlogConfigBackend
    {
        /// <summary>Constructs a new instance of <see cref="T:MyBlogLister.Config.Backends.Data.BlogConfigDataBackend" /> and returns a reference to it.</summary>
        public BlogConfigDataBackend(string connectionString)
        {
            ValidateConnectionString(connectionString);

            BloggingServiceManager.Instance.InitializeAll(connectionString);

            Blogs = Load(connectionString);
        }

        public IEnumerable<IBlogDto> Blogs { get; }

        public IEnumerable<IBlogDto> Load(dynamic dataSourceName)
        {
            return BlogService.Instance.GetAll()
                .Select(DbBlogDtoConverter.ToBlogDto).ToList();
        }

        public void Save(dynamic dataSourceName, IEnumerable<IBlogDto> data)
        {
            foreach (var blog in data) { }
        }

        private void ValidateConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException(
                    "Value cannot be blank.", nameof(connectionString)
                );
        }
    }
}