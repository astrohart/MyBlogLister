using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBlog
    {
        string Author { get; set; }
        int BlogId { get; set; }

        string Date { get; set; }
        string Name { get; set; }
        string Permalink { get; set; }

        ICollection<IPost> Posts { get; set; }
    }
}