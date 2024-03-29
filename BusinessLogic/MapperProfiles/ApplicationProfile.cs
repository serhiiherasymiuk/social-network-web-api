﻿using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Post, PostDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Comment, CommentDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<PostLike, PostLikeDTO>().ReverseMap();

            CreateMap<CommentLike, CommentLikeDTO>().ReverseMap();

            CreateMap<GroupChatMessage, GroupChatMessageDTO>().ReverseMap()
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<IndividualChatMessage, IndividualChatMessageDTO>().ReverseMap()
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<GroupChat, GroupChatDTO>().ReverseMap();

            CreateMap<IndividualChat, IndividualChatDTO>().ReverseMap();

            CreateMap<Follow, FollowDTO>().ReverseMap();

            CreateMap<Notification, NotificationDTO>().ReverseMap()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
