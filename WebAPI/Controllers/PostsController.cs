using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await postsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await postsService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var item = await postsService.GetByUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDTO createPostDTO)
        {
            await postsService.Create(createPostDTO);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PostDTO createPostDTO)
        {
            await postsService.Edit(createPostDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await postsService.Delete(id);
            return Ok();
        }
    }
}
