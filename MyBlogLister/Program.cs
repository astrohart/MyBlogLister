using System;
using System.IO;
using System.Reflection;
using MyBlogLister.Config;
using MyBlogLister.Config.Backends.Data;
using MyBlogLister.Config.Backends.Json;

namespace MyBlogLister
{
    public static class Program
    {
        public static string BlogDatabaseConnectionString =>
            @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=D:\Users\NCWDG_Developer\source\repos\astrohart\MyBlogLister\MyBlogLister.Data\bin\Debug\Blogging.mdf;integrated security=True;MultipleActiveResultSets=True;";

        private static string BlogJsonFileLocation =>
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ??
                string.Empty, "blogs.json"
            );

        public static void Main(string[] args)
        {
            while (MainMenu()) { }
        }

        private static void DislpayBlogs(DataSourceType type)
        {
            Console.Clear();
            Console.WriteLine(
                type == DataSourceType.JsonFile
                    ? "\n*** READING BLOGS FROM JSON FILE ***\n"
                    : "\n*** READING BLOGS FROM DATABASE ***\n"
            );

            Console.WriteLine("Here are your blogs:\n");

            var i = 0;
            foreach (var blog in BlogConfigProvider.Blogs)
            {
                Console.WriteLine($"{i + 1}. {blog.Name}");
                i++;
            }

            Console.WriteLine("\nPress any key to return to the Main Menu.\n");
            Console.ReadKey();
        }

        private static void LoadBlogsFromDatabase()
        {
            BlogConfigProvider.Backend =
                new BlogConfigDataBackend(BlogDatabaseConnectionString);
            DislpayBlogs(DataSourceType.Database);
        }

        private static void LoadBlogsFromJsonFile()
        {
            BlogConfigProvider.Backend = new BlogConfigJsonBackend(
                BlogJsonFileLocation
            );
            DislpayBlogs(DataSourceType.JsonFile);
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Load Blogs from JSON file");
            Console.WriteLine("2. Load Blogs from Database");
            Console.WriteLine("3. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    LoadBlogsFromJsonFile();
                    return true;

                case "2":
                    LoadBlogsFromDatabase();
                    return true;

                case "3":
                    return false;

                default:
                    return true;
            }
        }
    }
}