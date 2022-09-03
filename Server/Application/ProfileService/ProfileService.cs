using Microsoft.EntityFrameworkCore;
using Server.Application.Catalog.Posts;
using Server.Application.Catalog.Profile;
using Server.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly ServerDbContext _context;
        public ProfileService(ServerDbContext context)
        {
            _context = context;
        }
        public async Task<ProfileModel<ListPosts>> GetPostsProfile(PostsQuery request)
        {
            var query = from p in _context.Posts
                        where p.userId == request.userId
                        select new { p };
            var user = await _context.Users.FindAsync(request.userId);
            var totalRow = await query.CountAsync();

            var post = await query.Skip((request._pages - 1) * request._limit)
                                  .Take(request._limit)
                                  .Select(x => new ListPosts()
                                  {
                                      postId = x.p.postId,
                                      Title = x.p.Title,
                                      Leter = x.p.Leter,
                                      Image = x.p.Image,
                                      Images = user.Image,
                                      Name = user.Name,
                                      Like = x.p.Like,
                                      userId = x.p.userId
                                  }).ToListAsync();

            var result = new ProfileModel<ListPosts>()
            {
                Data = post,
                _pages = request._pages,
                _limit = request._limit,
                TotalRecord = totalRow
            };

            return result;
        }
    }
}
