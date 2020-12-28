using AutoMapper;
using MyBlogLister.Json.Models;

namespace MyBlogLister.DtoProvider
{
    public class BlogProfile : Profile
    {
        /// <summary>Constructs a new instance of <see cref="T:MyBlogLister.DtoProvider.BlogProfile" /> and returns a reference to it.</summary>
        public BlogProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Blog, BlogDto>().ReverseMap();
        }
    }
}