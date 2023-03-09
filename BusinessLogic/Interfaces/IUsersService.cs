using Core.Entities;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Create(User user);
        Task Edit(User user);
        Task Delete(int id);
    }
}