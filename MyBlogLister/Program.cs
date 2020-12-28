using System;
using System.IO;
using System.Reflection;
using MyBlogLister.Config;
using MyBlogLister.Config.Backends.Data;

namespace MyBlogLister
{
    public static class Program
    {
        private static string BlogJsonFileLocation =>
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ??
                string.Empty, "blogs.json"
            );

        public static void Main(string[] args)
        {
            BlogConfigProvider.Backend = new BlogConfigDataBackend(
                @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=D:\Users\NCWDG_Developer\source\repos\astrohart\MyBlogLister\MyBlogLister.Data\bin\Debug\Blogging.mdf;integrated security=True;MultipleActiveResultSets=True;"
            );
            //new BlogConfigJsonBackend(BlogJsonFileLocation);

            Console.WriteLine("Here are your blogs:\n");

            var i = 0;
            foreach (var blog in BlogConfigProvider.Blogs)
            {
                Console.WriteLine($"{i + 1}. {blog.Name}");
                i++;
            }

            Console.ReadKey();
        }
    }
}