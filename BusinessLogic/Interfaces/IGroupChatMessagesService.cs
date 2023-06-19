using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGroupChatMessagesService
    {
        Task<IEnumerable<GroupChatMessageDTO>> GetAll();
        Task<GroupChatMessageDTO?> GetById(int id);
        Task<IEnumerable<GroupChatMessageDTO>> GetByGroupChatId(int groupChatId);
        Task<IEnumerable<GroupChatMessageDTO>> GetByUserId(string userId);
        Task Create(GroupChatMessageDTO groupChatMessage);
        Task Edit(GroupChatMessageDTO groupChatMessage);
        Task Delete(int id);
    }
}
