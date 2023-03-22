using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowsService followsService;

        public FollowsController(IFollowsService followsService)
        {
            this.followsService = followsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await followsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await followsService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByFollowerId/{userId}")]
        public async Task<IActionResult> GetByFollowerId([FromRoute] string userId)
        {
            var item = await followsService.GetByFollowerId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByFollowedUserId/{userId}")]
        public async Task<IActionResult> GetByFollowedUserId([FromRoute] string userId)
        {
            var item = await followsService.GetByFollowedUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FollowDTO follow)
        {
            await followsService.Create(follow);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] FollowDTO follow)
        {
            await followsService.Edit(follow);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await followsService.Delete(id);
            return Ok();
        }
    }
}
