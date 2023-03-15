using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Comment, CommentDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Like, LikeDTO>().ReverseMap();

            CreateMap<Message, MessageDTO>().ReverseMap()
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Follow, FollowDTO>().ReverseMap();

            CreateMap<Notification, NotificationDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
