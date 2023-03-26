using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Core.Specifications;
using System.Net;

namespace Core.Services
{
    public class GroupChatMessagesService : IGroupChatMessagesService
    {
        private readonly IRepository<GroupChatMessage> groupChatMessagesRepo;
        private readonly IMapper mapper;

        public GroupChatMessagesService(IRepository<GroupChatMessage> groupChatMessagesRepo, IMapper mapper)
        {
            this.groupChatMessagesRepo = groupChatMessagesRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GroupChatMessageDTO>> GetAll()
        {
            var groupChatMessages = await groupChatMessagesRepo.GetAll();
            return mapper.Map<IEnumerable<GroupChatMessageDTO>>(groupChatMessages);
        }

        public async Task<IEnumerable<GroupChatMessageDTO>> GetByGroupChatId(int groupChatId)
        {
            var groupChatMessages = await groupChatMessagesRepo.GetAllBySpec(new GroupChatMessages.ByGroupChatId(groupChatId));
            return mapper.Map<IEnumerable<GroupChatMessageDTO>>(groupChatMessages);
        }

        public async Task<GroupChatMessageDTO?> GetById(int id)
        {
            GroupChatMessage groupChatMessage = await groupChatMessagesRepo.GetBySpec(new GroupChatMessages.ById(id));
            if (groupChatMessage == null)
                throw new HttpException(ErrorMessages.GroupChatMessageByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<GroupChatMessageDTO>(groupChatMessage);
        }

        public async Task<IEnumerable<GroupChatMessageDTO>> GetBySenderId(string userId)
        {
            var groupChatMessages = await groupChatMessagesRepo.GetAllBySpec(new GroupChatMessages.BySenderId(userId));
            return mapper.Map<IEnumerable<GroupChatMessageDTO>>(groupChatMessages);
        }
        public async Task Edit(GroupChatMessageDTO groupChatMessage)
        {
            await groupChatMessagesRepo.Update(mapper.Map<GroupChatMessage>(groupChatMessage));
            await groupChatMessagesRepo.Save();
        }

        public async Task Create(GroupChatMessageDTO groupChatMessage)
        {
            await groupChatMessagesRepo.Insert(mapper.Map<GroupChatMessage>(groupChatMessage));
            await groupChatMessagesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await groupChatMessagesRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.GroupChatMessageByIdNotFound, HttpStatusCode.NotFound);
            await groupChatMessagesRepo.Delete(id);
            await groupChatMessagesRepo.Save();
        }
    }
}
