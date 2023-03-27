using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualChatMessagesController : ControllerBase
    {
        private readonly IIndividualChatMessagesService individualChatMessagesService;

        public IndividualChatMessagesController(IIndividualChatMessagesService individualChatMessagesService)
        {
            this.individualChatMessagesService = individualChatMessagesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await individualChatMessagesService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await individualChatMessagesService.GetById(id));
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            return Ok(await individualChatMessagesService.GetByUserId(userId));
        }
        [HttpGet("getByIndividualChatId/{individualChatId}")]
        public async Task<IActionResult> GetByIndividualChatId([FromRoute] int individualChatId)
        {
            return Ok(await individualChatMessagesService.GetByIndividualChatId(individualChatId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IndividualChatMessageDTO individualChatMessage)
        {
            await individualChatMessagesService.Create(individualChatMessage);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] IndividualChatMessageDTO individualChatMessage)
        {
            await individualChatMessagesService.Edit(individualChatMessage);
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
