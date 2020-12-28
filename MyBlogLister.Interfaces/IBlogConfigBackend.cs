using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBlogConfigBackend : IBackend<IBlog>
    {
        IEnumerable<IBlog> Blogs { get; }
    }
}