using AutoMapper;
using MyBlogLister.Interfaces;

namespace MyBlogLister.DtoProvider
{
    public static class DbBlogDtoConverter
    {
        private static readonly MapperConfiguration _config =
            new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<IBlog, BlogDto>().ReverseMap();
                    cfg.CreateMap<IPost, IPostDto>().ReverseMap();
                }
            );

        public static IBlog ToBlog(this BlogDto dto) =>
            new Mapper(_config).Map<BlogDto, IBlog>(dto);

        public static BlogDto ToBlogDto(this IBlog jsonBlog) =>
            new Mapper(_config).Map<IBlog, BlogDto>(jsonBlog);
    }
}