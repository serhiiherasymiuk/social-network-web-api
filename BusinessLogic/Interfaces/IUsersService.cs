using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO?> GetById(int id);
        Task Create(UserDTO user);
        Task Edit(UserDTO user);
        Task Delete(int id);
    }
}