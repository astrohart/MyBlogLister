using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBlogConfigBackend : IBackend<IBlogDto>
    {
        IEnumerable<IBlogDto> Blogs { get; }
    }
}