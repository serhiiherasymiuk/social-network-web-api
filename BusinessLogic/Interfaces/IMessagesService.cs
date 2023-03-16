using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMessagesService
    {
        Task<IEnumerable<MessageDTO>> GetAll();
        Task<MessageDTO?> GetById(int id);
        Task<IEnumerable<MessageDTO>> GetBySenderId(string userId);
        Task<IEnumerable<MessageDTO>> GetByRecipientId(string userId);
        Task Create(MessageDTO message);
        Task Edit(MessageDTO message);
        Task Delete(int id);
    }
}
