using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly IRepository<Notification> notificationsRepo;
        private readonly IMapper mapper;

        public NotificationsService(IRepository<Notification> notificationsRepo, IMapper mapper)
        {
            this.notificationsRepo = notificationsRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<NotificationDTO>> GetAll()
        {
            var notifications = await notificationsRepo.GetAll();
            return mapper.Map<IEnumerable<NotificationDTO>>(notifications);
        }

        public async Task<NotificationDTO?> GetById(int id)
        {
            Notification notification = await notificationsRepo.GetBySpec(new Notifications.ById(id));
            if (notification == null)
                throw new HttpException(ErrorMessages.NotificationByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<NotificationDTO>(notification);
        }

        public async Task<IEnumerable<NotificationDTO>> GetByUserId(string userId)
        {
            var notifications = await notificationsRepo.GetAllBySpec(new Notifications.ByUserId(userId));
            return mapper.Map<IEnumerable<NotificationDTO>>(notifications);
        }
        public async Task Edit(NotificationDTO notification)
        {
            await notificationsRepo.Update(mapper.Map<Notification>(notification));
            await notificationsRepo.Save();
        }

        public async Task Create(NotificationDTO notification)
        {
            await notificationsRepo.Insert(mapper.Map<Notification>(notification));
            await notificationsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await notificationsRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.NotificationByIdNotFound, HttpStatusCode.NotFound);
            await notificationsRepo.Delete(id);
            await notificationsRepo.Save();
        }
    }
}
