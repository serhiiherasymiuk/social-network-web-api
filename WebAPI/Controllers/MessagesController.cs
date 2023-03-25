using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        /*private readonly IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await messagesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await messagesService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getBySenderId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var item = await messagesService.GetBySenderId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByRecipientId/{userId}")]
        public async Task<IActionResult> GetByRecipientId([FromRoute] string userId)
        {
            var item = await messagesService.GetByRecipientId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessageDTO message)
        {
            await messagesService.Create(message);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] MessageDTO message)
        {
            await messagesService.Edit(message);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await messagesService.Delete(id);
            return Ok();
        }*/
    }
}
