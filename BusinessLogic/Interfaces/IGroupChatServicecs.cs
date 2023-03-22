using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGroupChatService
    {
        Task<GroupChatDTO> GetById(int id);
        Task<IEnumerable<GroupChatDTO>> GetAll();
        Task<GroupChatDTO> Create(GroupChatDTO groupChatDto);
        Task<GroupChatDTO> Update(GroupChatDTO groupChatDto);
        Task Delete(int id);
        Task<IEnumerable<UserDTO>> GetUsers(int groupChatId);
        Task<UserDTO> AddUser(int groupChatId, UserDTO groupChatUserDto);
        Task RemoveUser(int groupChatId, string userId);
        Task<IEnumerable<GroupChatMessageDTO>> GetMessages(int id);
        Task<GroupChatMessageDTO> AddMessage(int id, GroupChatMessageDTO groupChatMessageDto);
    }
}
