using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostLikesController : ControllerBase
    {
        private readonly IPostLikesService postLikesService;

        public PostLikesController(IPostLikesService postLikesService)
        {
            this.postLikesService = postLikesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await postLikesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await postLikesService.GetById(id));
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var item = await postLikesService.GetByUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByPostId/{postId}")]
        public async Task<IActionResult> GetByPostId([FromRoute] int postId)
        {
            var item = await postLikesService.GetByPostId(postId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostLikeDTO postLike)
        {
            await postLikesService.Create(postLike);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PostLikeDTO postLike)
        {
            await postLikesService.Edit(postLike);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await postLikesService.Delete(id);
            return Ok();
        }
    }
}
