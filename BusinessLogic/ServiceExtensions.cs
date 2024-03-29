﻿using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOpenAIService, OpenAIService>();
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IPostLikesService, PostLikesService>();
            services.AddScoped<ICommentLikesService, CommentLikesService>();
            services.AddScoped<IFollowsService, FollowsService>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IGroupChatsService, GroupChatsService>(); 
            services.AddScoped<IIndividualChatsService, IndividualChatsService>();
            services.AddScoped<IGroupChatMessagesService, GroupChatMessagesService>();
            services.AddScoped<IIndividualChatMessagesService, IndividualChatMessagesService>();
        }
    }
}