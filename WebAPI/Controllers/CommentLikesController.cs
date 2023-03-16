using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentLikesController : ControllerBase
    {
        private readonly ICommentLikesService commentLikesService;

        public CommentLikesController(ICommentLikesService commentLikesService)
        {
            this.commentLikesService = commentLikesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await commentLikesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await commentLikesService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            var item = await commentLikesService.GetByUserId(userId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpGet("getByCommentId/{postId}")]
        public async Task<IActionResult> GetByCommentId([FromRoute] int commentId)
        {
            var item = await commentLikesService.GetByCommentId(commentId);
            if (item == null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentLikeDTO commentLike)
        {
            await commentLikesService.Create(commentLike);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CommentLikeDTO commentLike)
        {
            await commentLikesService.Edit(commentLike);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await commentLikesService.Delete(id);
            return Ok();
        }
    }
}
