using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IIndividualChatsService
    {
        Task<IEnumerable<IndividualChatDTO>> GetAll();
        Task<IndividualChatDTO?> GetById(int id);
        Task<IEnumerable<IndividualChatDTO>> GetByUserId(string userId);
        Task Create(IndividualChatDTO individualChat);
        Task Edit(IndividualChatDTO individualChat);
        Task Delete(int id);
    }
}
