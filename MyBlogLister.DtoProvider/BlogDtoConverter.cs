using System.Collections.Generic;
using AutoMapper;
using MyBlogLister.Interfaces;
using MyBlogLister.Json.Models;

namespace MyBlogLister.DtoProvider
{
    public static class BlogDtoConverter
    {
        private static readonly MapperConfiguration _config =
            new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<List<Post>, List<IPostDto>>();
                    cfg.CreateMap<Blog, BlogDto>().ForMember(
                        dto => dto.Posts, map => map.MapFrom(src => src.Posts)
                    );
                }
            );

        public static Blog ToBlog(this BlogDto dto) =>
            new Mapper(_config).Map<BlogDto, Blog>(dto);

        public static BlogDto ToBlogDto(this Blog blog) =>
            new Mapper(_config).Map<Blog, BlogDto>(blog);
    }
}