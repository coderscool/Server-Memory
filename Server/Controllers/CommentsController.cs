using Microsoft.AspNetCore.Mvc;
using Server.Application.Catalog.Comments;
using Server.Application.CommentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CommentRequest request)
        {
            var result = await _commentService.CreateComment(request);
            if (result == 0)
                return BadRequest();

            var comment = await _commentService.GetById(result);

            return CreatedAtAction(nameof(GetById), new { commentId = result }, comment);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] GetCommentIdRequest request)
        {
            var comments = await _commentService.GetById(request.commentId);
            if (comments == null)
                return BadRequest();
            return Ok(comments);
        }
        [HttpGet("comment")]
        public async Task<IActionResult> GetAllComment([FromQuery] GetCommentRequest request)
        {
            var result = await _commentService.GetAllComments(request);
            return Ok(result);
        }
        [HttpGet("replycomment")]
        public async Task<IActionResult> GetAllReplyComment([FromQuery] GetReplyCommentRequest request)
        {
            var result = await _commentService.GetAllReplyComments(request);
            return Ok(result);
        }
    }
}
