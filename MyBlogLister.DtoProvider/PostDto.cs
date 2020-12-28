using MyBlogLister.Interfaces;

namespace MyBlogLister.DtoProvider
{
    public class PostDto : IPostDto
    {
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Permalink { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
    }
}