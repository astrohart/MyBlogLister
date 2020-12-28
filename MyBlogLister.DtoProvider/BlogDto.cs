using System.Collections.Generic;
using MyBlogLister.Interfaces;

namespace MyBlogLister.DtoProvider
{
    public class BlogDto : IBlogDto
    {
        public string Author { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Permalink { get; set; }
        public List<IPostDto> Posts { get; set; }
    }
}