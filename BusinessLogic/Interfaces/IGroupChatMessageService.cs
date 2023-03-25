using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGroupChatMessageService
    {
        Task<IEnumerable<GroupChatMessageDTO>> GetAll();
        Task<GroupChatMessageDTO?> GetById(int id);
        Task<IEnumerable<GroupChatMessageDTO>> GetByGroupChatId(int groupChatId);
        Task<IEnumerable<GroupChatMessageDTO>> GetBySenderId(int userId);
        Task Create(GroupChatMessageDTO groupChatMessage);
        Task Edit(GroupChatMessageDTO groupChatMessage);
        Task Delete(int id);
    }
}
