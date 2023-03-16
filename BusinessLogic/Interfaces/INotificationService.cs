using Core.DTOs;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetAll();
        Task<NotificationDTO?> GetById(int id);
        Task<IEnumerable<NotificationDTO>> GetByUserId(string userId);
        Task Create(NotificationDTO notification);
        Task Edit(NotificationDTO notification);
        Task Delete(int id);
    }
}
