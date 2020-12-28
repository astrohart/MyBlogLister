using System.Collections.Generic;
using AutoMapper;
using MyBlogLister.Data;
using MyBlogLister.Interfaces;

namespace MyBlogLister.DtoProvider
{
    public static class DbBlogDtoConverter
    {
        private static readonly MapperConfiguration _config =
            new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Blog, BlogDto>().ForMember(
                        dto => dto.Posts, map => map.MapFrom(src => src.Posts)
                    );
                    cfg.CreateMap<ICollection<Post>, List<IPostDto>>();
                }
            );

        public static Blog ToBlog(this BlogDto dto) =>
            new Mapper(_config).Map<BlogDto, Blog>(dto);

        public static BlogDto ToBlogDto(this Blog jsonBlog) =>
            new Mapper(_config).Map<Blog, BlogDto>(jsonBlog);
    }
}