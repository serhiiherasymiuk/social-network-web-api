using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualChatsController : ControllerBase
    {
        private readonly IIndividualChatsService individualChatsService;

        public IndividualChatsController(IIndividualChatsService individualChatsService)
        {
            this.individualChatsService = individualChatsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await individualChatsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await individualChatsService.GetById(id));
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            return Ok(await individualChatsService.GetByUserId(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IndividualChatDTO individualChat)
        {
            await individualChatsService.Create(individualChat);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] IndividualChatDTO individualChat)
        {
            await individualChatsService.Edit(individualChat);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await individualChatsService.Delete(id);
            return Ok();
        }
    }
}
