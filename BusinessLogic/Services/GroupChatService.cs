using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GroupChatService : IGroupChatService
    {
        private readonly IRepository<User> usersRepo;
        private readonly IRepository<GroupChat> groupChatsRepo;
        private readonly IMapper mapper;

        public GroupChatService(IRepository<GroupChat> groupChatsRepo, IRepository<User> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
            this.groupChatsRepo = groupChatsRepo;
            this.mapper = mapper;
        }

        public async Task AddUser(int groupChatId, string userId)
        {
            GroupChat groupChat = await groupChatsRepo.GetBySpec(new GroupChats.ById(groupChatId));
            if (groupChat == null)
                throw new HttpException(ErrorMessages.GroupChatByIdNotFound, HttpStatusCode.NotFound);
            User user = await usersRepo.GetBySpec(new Users.ById(userId));
            if (groupChat == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);
            groupChat.Members.Add(user);
            await groupChatsRepo.Save();
        }

        public async Task Create(GroupChatDTO groupChat)
        {
            await groupChatsRepo.Insert(mapper.Map<GroupChat>(groupChat));
            await groupChatsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await groupChatsRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.GroupChatByIdNotFound, HttpStatusCode.NotFound);
            await groupChatsRepo.Delete(id);
            await groupChatsRepo.Save();
        }

        public async Task<IEnumerable<GroupChatDTO>> GetAll()
        {
            var groupChat = await groupChatsRepo.GetBySpec(new GroupChats.All());
            if (groupChat == null)
                throw new HttpException(ErrorMessages.GroupChatByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<IEnumerable<GroupChatDTO>>(groupChat);
        }

        public async Task<GroupChatDTO> GetById(int id)
        {
            GroupChat groupChat = await groupChatsRepo.GetBySpec(new GroupChats.ById(id));
            if (groupChat == null)
                throw new HttpException(ErrorMessages.GroupChatByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<GroupChatDTO>(groupChat);
        }

        public async Task RemoveUser(int groupChatId, string userId)
        {
            GroupChat groupChat = await groupChatsRepo.GetBySpec(new GroupChats.ById(groupChatId));
            if (groupChat == null)
                throw new HttpException(ErrorMessages.GroupChatByIdNotFound, HttpStatusCode.NotFound);
            User user = await usersRepo.GetBySpec(new Users.ById(userId));
            if (groupChat == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);
            groupChat.Members.Remove(user);
            await groupChatsRepo.Save();
        }

        public async Task Edit(GroupChatDTO groupChat)
        {
            await groupChatsRepo.Update(mapper.Map<GroupChat>(groupChat));
            await groupChatsRepo.Save();
        }
    }
}
