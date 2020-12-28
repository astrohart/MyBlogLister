using AutoMapper;
using MyBlogLister.Interfaces;
using MyBlogLister.Json.Models;

namespace MyBlogLister.DtoProvider
{
    public static class JsonBlogDtoConverter
    {
        private static readonly MapperConfiguration _config =
            new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<JsonBlog, BlogDto>().ForMember(
                            dto => dto.Posts,
                            map => map.MapFrom(src => src.Posts)
                        ).ForMember(x => x.BlogId, opt => opt.Ignore())
                        .ReverseMap();
                    cfg.CreateMap<JsonPost, IPostDto>()
                        .ForMember(x => x.PostId, opt => opt.Ignore())
                        .ForMember(x => x.BlogId, opt => opt.Ignore())
                        .ReverseMap();
                }
            );

        public static JsonBlog ToBlog(this BlogDto dto) =>
            new Mapper(_config).Map<BlogDto, JsonBlog>(dto);

        public static BlogDto ToBlogDto(this JsonBlog jsonBlog) =>
            new Mapper(_config).Map<JsonBlog, BlogDto>(jsonBlog);
    }
}