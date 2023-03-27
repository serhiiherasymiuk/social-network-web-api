using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IIndividualChatMessagesService
    {
        Task<IEnumerable<IndividualChatMessageDTO>> GetAll();
        Task<IndividualChatMessageDTO?> GetById(int id);
        Task<IEnumerable<IndividualChatMessageDTO>> GetByIndividualChatId(int individualChatId);
        Task<IEnumerable<IndividualChatMessageDTO>> GetByUserId(string userId);
        Task Create(IndividualChatMessageDTO individualChatMessage);
        Task Edit(IndividualChatMessageDTO individualChatMessage);
        Task Delete(int id);
    }
}
