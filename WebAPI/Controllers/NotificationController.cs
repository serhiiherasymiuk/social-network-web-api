using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationsService notificationService;

        public NotificationController(INotificationsService notificationService)
        {
            this.notificationService = notificationService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await notificationService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await notificationService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var item = await notificationService.GetByUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationDTO notification)
        {
            await notificationService.Create(notification);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] NotificationDTO notification)
        {
            await notificationService.Edit(notification);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await notificationService.Delete(id);
            return Ok();
        }
    }
}
