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
    internal class IndividualChatsService : IIndividualChatsService
    {
        private readonly IRepository<IndividualChat> individualChatsRepo;
        private readonly IMapper mapper;

        public IndividualChatsService(IRepository<IndividualChat> individualChatsRepo, IMapper mapper)
        {
            this.individualChatsRepo = individualChatsRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IndividualChatDTO>> GetAll()
        {
            var individualChats = await individualChatsRepo.GetAllBySpec(new IndividualChats.All());
            return mapper.Map<IEnumerable<IndividualChatDTO>>(individualChats);
        }

        public async Task<IndividualChatDTO?> GetById(int id)
        {
            IndividualChat individualChat = await individualChatsRepo.GetBySpec(new IndividualChats.ById(id));
            if (individualChat == null)
                throw new HttpException(ErrorMessages.IndividualChatByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<IndividualChatDTO>(individualChat);
        }

        public async Task<IEnumerable<IndividualChatDTO>> GetByUserId(string userId)
        {
            var individualChats = await individualChatsRepo.GetAllBySpec(new IndividualChats.ByUserId(userId));
            return mapper.Map<IEnumerable<IndividualChatDTO>>(individualChats);
        }

        public async Task Create(IndividualChatDTO individualChat)
        {
            await individualChatsRepo.Insert(mapper.Map<IndividualChat>(individualChat));
            await individualChatsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await individualChatsRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.IndividualChatByIdNotFound, HttpStatusCode.NotFound);
            await individualChatsRepo.Delete(id);
            await individualChatsRepo.Save();
        }

        public async Task Edit(IndividualChatDTO individualChat)
        {
            await individualChatsRepo.Update(mapper.Map<IndividualChat>(individualChat));
            await individualChatsRepo.Save();
        }
    }
}
