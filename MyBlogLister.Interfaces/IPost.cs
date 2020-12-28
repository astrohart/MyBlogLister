namespace MyBlogLister.Interfaces
{
    public interface IPost
    {
        string Content { get; set; }
        string Date { get; set; }
        string Permalink { get; set; }
        string Title { get; set; }
    }
}