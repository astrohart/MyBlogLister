using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBlogDto
    {
        string Author { get; set; }
        string Date { get; set; }
        string Name { get; set; }
        string Permalink { get; set; }
        List<IPostDto> Posts { get; set; }
    }
}