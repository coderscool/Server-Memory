using Microsoft.EntityFrameworkCore;
using Server.Application.Catalog.Posts;
using Server.Data.EF;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.PostsService
{
    public class PostsService : IPostsService
    {
        private readonly ServerDbContext _context;
        public PostsService(ServerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PostsCreateRequest resquest)
        {
            var post = new Posts()
            {
                userId = resquest.userId,
                Title = resquest.title,
                Leter = resquest.leter,
                Like = 0,
                Image = resquest.image
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.postId;
        }

        public async Task<int> Delete(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            _context.Posts.Remove(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageModel<ListPosts>> GetAllPaging(GetPagingRequest request)
        {
            var query = from p in _context.Posts
                        join u in _context.Users on p.userId equals u.userId
                        select new { p, u };

            var totalRow = await _context.Posts.CountAsync();
            var data = await query.Skip((request._pages - 1) * request._limit)
                                  .Take(request._limit)
                                  .Select(x => new ListPosts()
                                  {
                                      postId = x.p.postId,
                                      Title = x.p.Title,
                                      Leter = x.p.Leter,
                                      Image = x.p.Image,
                                      Images = x.u.Image,
                                      Name = x.u.Name,
                                      Like = x.p.Like,
                                      userId = x.p.userId
                                  }).ToListAsync();

            var result = new PageModel<ListPosts>()
            {
                Data = data,
                _pages = request._pages,
                _limit = request._limit,
                TotalRecord = totalRow
            };

            return result;
        }

        public async Task<Posts> GetById(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            return post;
        }

        public async Task<PageModel<ListPosts>> GetFilterPaging(GetFilterRequest request)
        {
            var query = from p in _context.Posts
                        join u in _context.Users on p.userId equals u.userId
                        where p.Title == request._key
                        select new { p, u };

            var totalRow = await query.CountAsync();
            var data = await query.Skip((request._pages - 1) * request._limit)
                                  .Take(request._limit)
                                  .Select(x => new ListPosts()
                                  {
                                      postId = x.p.postId,
                                      Title = x.p.Title,
                                      Leter = x.p.Leter,
                                      Image = x.p.Image,
                                      Images = x.u.Image,
                                      Name = x.u.Name,
                                      Like = x.p.Like,
                                      userId = x.p.userId
                                  }).ToListAsync();

            var result = new PageModel<ListPosts>()
            {
                Data = data,
                _pages = request._pages,
                _limit = request._limit,
                TotalRecord = totalRow
            };

            return result;
        }

        public async Task<ListPosts> GetShowPost(GetPostIdRequest request)
        {
            var post = await _context.Posts.FindAsync(request.postId);

            var user = await _context.Users.FindAsync(post.userId);

            var data = new ListPosts()
            {
                userId = user.userId,
                postId = post.postId,
                Name = user.Name,
                Title = post.Title,
                Leter = post.Leter,
                Image = post.Image,
                Images = user.Image,
                Like = post.Like
            };
            return data;
        }

        public async Task<int> PostUpdateRequest(UpdateRequest request)
        {
            var post = await _context.Posts.FindAsync(request.postId);
            if (post == null) throw new Exception("cannot find a pictur");

            post.Leter = request.leter;
            post.Title = request.title;
            post.Image = request.image;
            post.Like = request.like;
            post.userId = request.userId;

            return await _context.SaveChangesAsync();
        }
    }
}
