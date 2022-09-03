using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Catalog.Friends;
using Server.Application.FriendService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;
        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        [HttpGet("friend")]
        public async Task<IActionResult> GetMakeFriend([FromQuery] FriendQuery request)
        {
            var result = await _friendService.Message(request);
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdFriend(int friendId)
        {
            var friends = await _friendService.GetByIdFriend(friendId);
            if (friends == null)
                return BadRequest();
            return Ok(friends);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] FriendQuery resquest)
        {
            var result = await _friendService.CreateFriend(resquest);
            if (result == 0)
                return BadRequest();

            var friends = await _friendService.GetByIdFriend(result);

            return CreatedAtAction(nameof(GetByIdFriend), new { friendId = result }, friends);
        }

        [HttpGet("myfriend")]
        public async Task<IActionResult> GetAllFriend([FromQuery] GetFriends request)
        {
            var result = await _friendService.GetListFriends(request);
            return Ok(result);
        }

        [HttpDelete("{friendId}")]
        public async Task<IActionResult> DeleteFriend(int friendId)
        {
            var result = await _friendService.DeleteFriend(friendId);
            return Ok(result);
        }

        [HttpPut("{friendId}")]
        public async Task<IActionResult> Update(int friendId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _friendService.AcceptFriend(friendId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
