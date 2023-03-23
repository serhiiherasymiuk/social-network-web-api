using Core.DTOs;

namespace Core.Interfaces
{
    public interface IGroupChatService
    {
        Task<GroupChatDTO> GetById(int id);
        Task<IEnumerable<GroupChatDTO>> GetAll();
        Task Create(GroupChatDTO groupChatDto);
        Task Edit(GroupChatDTO groupChatDto);
        Task Delete(int id);
        Task AddUser(int groupChatId, string userId);
        Task RemoveUser(int groupChatId, string userId);
    }
}
