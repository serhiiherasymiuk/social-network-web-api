﻿using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await postsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await postsService.GetById(id));
        }
        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
        {
            return Ok(await postsService.GetByUserId(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDTO post)
        {
            await postsService.Create(post);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PostDTO post)
        {
            await postsService.Edit(post);
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
