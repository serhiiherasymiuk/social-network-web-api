using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatMessagesController : ControllerBase
    {
        private readonly IGroupChatMessagesService groupChatMessagesService;

        public GroupChatMessagesController(IGroupChatMessagesService groupChatMessagesService)
        {
            this.groupChatMessagesService = groupChatMessagesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await groupChatMessagesService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await groupChatMessagesService.GetById(id));
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            return Ok(await groupChatMessagesService.GetByUserId(userId));
        }
        [HttpGet("getByGroupChatId/{groupChatId}")]
        public async Task<IActionResult> GetByGroupChatId([FromRoute] int groupChatId)
        {
            return Ok(await groupChatMessagesService.GetByGroupChatId(groupChatId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupChatMessageDTO groupChatMessage)
        {
            await groupChatMessagesService.Create(groupChatMessage);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] GroupChatMessageDTO groupChatMessage)
        {
            await groupChatMessagesService.Edit(groupChatMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await groupChatMessagesService.Delete(id);
            return Ok();
        }
    }
}
