using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyBlogLister.DtoProvider;
using MyBlogLister.Interfaces;
using MyBlogLister.Json.Models;

namespace MyBlogLister.Config.Backends.Json
{
    public class BlogConfigJsonBackend : IBlogConfigBackend
    {
        /// <summary>Constructs a new instance of <see cref="T:MyBlogLister.Config.Backends.Json.BlogConfigJsonBackend" /> and returns a reference to it.</summary>
        /// <param name="configFilePath">(Required.) String containing the path to the config file.</param>
        /// <exception cref="T:System.ArgumentException">Thrown if the <paramref name="configFilePath" /> is blank.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">Thrown if the system cannot locate the file specified.</exception>
        public BlogConfigJsonBackend(string configFilePath)
        {
            ValidateConfigFilePath(configFilePath);

            Blogs = Load(configFilePath);
        }

        public IEnumerable<IBlogDto> Blogs { get; }

        public IEnumerable<IBlogDto> Load(dynamic dataSourceName)
        {
            // Assume dataSourceName is a string containing the path name of
            // a file on the disk.  This file is a text file that has pure JSON
            // content, corresponding to our BlogUniverse model.
            ValidateConfigFilePath(dataSourceName);

            var jsonContent = File.ReadAllText(dataSourceName) as string;
            if (string.IsNullOrWhiteSpace(jsonContent))
                throw new InvalidOperationException(
                    $"Failed to read JSON content from configuration file '{dataSourceName}'."
                );

            return BlogSerializer.FromJson(jsonContent).Blogs
                .Select(BlogDtoConverter.ToBlogDto);
        }

        public void Save(dynamic dataSourceName, IEnumerable<IBlogDto> data) =>
            throw new NotImplementedException();

        private static void ValidateConfigFilePath(string configFilePath)
        {
            if (string.IsNullOrWhiteSpace(configFilePath))
                throw new ArgumentException(
                    "Value cannot be null or whitespace.",
                    nameof(configFilePath)
                );

            if (!File.Exists(configFilePath))
                throw new FileNotFoundException(
                    "File cannot be found", configFilePath
                );
        }
    }
}