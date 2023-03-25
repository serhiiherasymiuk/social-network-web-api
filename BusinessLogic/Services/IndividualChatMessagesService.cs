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
    public class IndividualChatMessagesService
    {
        private readonly IRepository<IndividualChatMessage> individualChatMessagesRepo;
        private readonly IMapper mapper;

        public IndividualChatMessagesService(IRepository<IndividualChatMessage> individualChatMessagesRepo, IMapper mapper)
        {
            this.individualChatMessagesRepo = individualChatMessagesRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<IndividualChatMessage>> GetAll()
        {
            var individualChatMessages = await individualChatMessagesRepo.GetAll();
            return mapper.Map<IEnumerable<IndividualChatMessage>>(individualChatMessages);
        }

        public async Task<IEnumerable<IndividualChatMessage>> GetByIndividualChatId(int individualChatId)
        {
            var individualChatMessages = await individualChatMessagesRepo.GetAllBySpec(new IndividualChatMessages.ByIndividualChatId(individualChatId));
            return mapper.Map<IEnumerable<IndividualChatMessage>>(individualChatMessages);
        }

        public async Task<IndividualChatMessage?> GetById(int id)
        {
            IndividualChatMessage individualChatMessage = await individualChatMessagesRepo.GetBySpec(new IndividualChatMessages.ById(id));
            if (individualChatMessage == null)
                throw new HttpException(ErrorMessages.IndividualChatMessageByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<IndividualChatMessage>(individualChatMessage);
        }

        public async Task<IEnumerable<IndividualChatMessage>> GetBySenderId(string userId)
        {
            var individualChatMessage = await individualChatMessagesRepo.GetAllBySpec(new IndividualChatMessages.BySenderId(userId));
            return mapper.Map<IEnumerable<IndividualChatMessage>>(individualChatMessage);
        }
        public async Task Edit(IndividualChatMessage individualChatMessage)
        {
            await individualChatMessagesRepo.Update(mapper.Map<IndividualChatMessage>(individualChatMessage));
            await individualChatMessagesRepo.Save();
        }

        public async Task Create(IndividualChatMessage individualChatMessage)
        {
            await individualChatMessagesRepo.Insert(mapper.Map<IndividualChatMessage>(individualChatMessage));
            await individualChatMessagesRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await individualChatMessagesRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.IndividualChatMessageByIdNotFound, HttpStatusCode.NotFound);
            await individualChatMessagesRepo.Delete(id);
            await individualChatMessagesRepo.Save();
        }
    }
}
