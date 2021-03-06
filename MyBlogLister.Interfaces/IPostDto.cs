﻿namespace MyBlogLister.Interfaces
{
    public interface IPostDto
    {
        int BlogId { get; set; }
        string Content { get; set; }
        string Date { get; set; }
        string Permalink { get; set; }
        int PostId { get; set; }
        string Title { get; set; }
    }
}