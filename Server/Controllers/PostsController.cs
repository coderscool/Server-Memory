using Microsoft.AspNetCore.Mvc;
using Server.Application.Catalog.Posts;
using Server.Application.Catalog.Profile;
using Server.Application.PostsService;
using Server.Application.ProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        private readonly IProfileService _profileService;
        public PostsController(IPostsService postsService, IProfileService profileService)
        {
            _postsService = postsService;
            _profileService = profileService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostsCreateRequest resquest)
        {
            var result = await _postsService.Create(resquest);
            if (result == 0)
                return BadRequest();

            var post = await _postsService.GetById(result);

            return CreatedAtAction(nameof(GetById), new { postId = result }, post);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] GetPostIdRequest request)
        {
            var posts = await _postsService.GetById(request.postId);
            if (posts == null)
                return BadRequest();
            return Ok(posts);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAll([FromQuery] GetPagingRequest request)
        {
            var result = await _postsService.GetAllPaging(request);
            return Ok(result);
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfilePost([FromQuery] PostsQuery request)
        {
            var result = await _profileService.GetPostsProfile(request);
            return Ok(result);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilterPaging([FromQuery] GetFilterRequest request)
        {
            var result = await _postsService.GetFilterPaging(request);
            return Ok(result);
        }
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(int postId)
        {
            var result = await _postsService.Delete(postId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.postId = Id;
            var affectedResult = await _postsService.PostUpdateRequest(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("showpost")]
        public async Task<IActionResult> GetShowPost([FromQuery] GetPostIdRequest request)
        {
            var result = await _postsService.GetShowPost(request);
            return Ok(result);
        }
    }
}
