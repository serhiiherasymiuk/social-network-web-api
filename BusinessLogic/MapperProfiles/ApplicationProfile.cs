using AutoMapper;
using Core.DTOs.Posts;
using Core.Entities;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
