using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatsController : ControllerBase
    {
        private readonly IGroupChatsService groupChatsService;

        public GroupChatsController(IGroupChatsService groupChatsService)
        {
            this.groupChatsService = groupChatsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await groupChatsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await groupChatsService.GetById(id));
        }

        [HttpPost("addUser/{groupChatId}/{userId}")]
        public async Task<IActionResult> AddUser([FromRoute] int groupChatId, [FromRoute] string userId)
        {
            await groupChatsService.AddUser(groupChatId, userId);
            return Ok();
        }
        [HttpDelete("removeUser/{groupChatId}/{userId}")]
        public async Task<IActionResult> RemoveUser([FromRoute] int groupChatId, [FromRoute] string userId)
        {
            await groupChatsService.RemoveUser(groupChatId, userId);
            return Ok();
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var item = await groupChatsService.GetByUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupChatDTO groupChat)
        {
            await groupChatsService.Create(groupChat);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] GroupChatDTO groupChat)
        {
            await groupChatsService.Edit(groupChat);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await groupChatsService.Delete(id);
            return Ok();
        }
    }
}
