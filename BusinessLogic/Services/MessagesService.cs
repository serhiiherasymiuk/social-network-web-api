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
    public class MessagesService : IMessagesService
    {
        private readonly IRepository<GroupChatMessage> messagesRepo;
        private readonly IMapper mapper;

        public MessagesService(IRepository<GroupChatMessage> messagesRepo, IMapper mapper)
        {
            this.messagesRepo = messagesRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MessageDTO>> GetAll()
        {
            var messages = await messagesRepo.GetAll();
            return mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
        public async Task<MessageDTO?> GetById(int id)
        {
            GroupChatMessage message = await messagesRepo.GetBySpec(new Messages.ById(id));
            if (message == null)
                throw new HttpException(ErrorMessages.MessageByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<MessageDTO>(message);
        }
        public async Task<IEnumerable<MessageDTO>> GetBySenderId(string userId)
        {
            var messages = await messagesRepo.GetAllBySpec(new Messages.BySenderId(userId));
            return mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
        public async Task<IEnumerable<MessageDTO>> GetByRecipientId(string userId)
        {
            var messages = await messagesRepo.GetAllBySpec(new Messages.ByRecipientId(userId));
            return mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
        public async Task Edit(MessageDTO message)
        {
            await messagesRepo.Update(mapper.Map<GroupChatMessage>(message));
            await messagesRepo.Save();
        }

        public async Task Create(MessageDTO message)
        {
            await messagesRepo.Insert(mapper.Map<GroupChatMessage>(message));
            await messagesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await messagesRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.MessageByIdNotFound, HttpStatusCode.NotFound);
            await messagesRepo.Delete(id);
            await messagesRepo.Save();
        }
    }
}
