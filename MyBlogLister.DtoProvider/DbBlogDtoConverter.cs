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
                    cfg.CreateMap<IBlog<Post>, BlogDto>().ReverseMap();
                    cfg.CreateMap<IPost, IPostDto>().ReverseMap();
                }
            );

        public static IBlog<Post> ToBlog(this BlogDto dto) =>
            new Mapper(_config).Map<BlogDto, IBlog<Post>>(dto);

        public static BlogDto ToBlogDto(this IBlog<Post> dataBlog) =>
            new Mapper(_config).Map<IBlog<Post>, BlogDto>(dataBlog);
    }
}