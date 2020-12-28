using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBlog<TPost> where TPost : IPost
    {
        string Author { get; set; }
        int BlogId { get; set; }

        string Date { get; set; }
        string Name { get; set; }
        string Permalink { get; set; }

        ICollection<TPost> Posts { get; set; }
    }
}