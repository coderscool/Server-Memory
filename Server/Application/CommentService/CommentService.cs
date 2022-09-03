using Microsoft.EntityFrameworkCore;
using Server.Application.Catalog.Comments;
using Server.Data.EF;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ServerDbContext _context;
        public CommentService(ServerDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateComment(CommentRequest request)
        {
            var comment = await _context.Comments.FindAsync(request.replyId);
            if (comment == null)
            {
                
            }
            else
            {
                comment.Count = comment.Count + 1;
            }


            var com = new Comments()
            {
                userId = request.userId,
                Comment = request.Comment,
                replyId = request.replyId,
                postId = request.postId,
                Count = 0
            };
            _context.Comments.Add(com);
            await _context.SaveChangesAsync();
            return com.commentId;
        }

        public Task<int> Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentModel<ListComments>> GetAllComments(GetCommentRequest request)
        {
            var query = from c in _context.Comments
                        where c.replyId == 0 && c.postId == request.postId
                        join u in _context.Users on c.userId equals u.userId
                        select new { c, u };

            var comment = await query.Select(x => new ListComments()
            {
                postId = x.c.postId,
                userId = x.c.userId,
                commentId = x.c.commentId,
                replyId = x.c.replyId,
                Comment = x.c.Comment,
                Count = x.c.Count,
                Open = false,
                Name = x.u.Name,
                Image = x.u.Image
            }).ToListAsync();

            var result = new CommentModel<ListComments>()
            {
                data = comment
            };

            return result; 
        }

        public async Task<CommentModel<ListComments>> GetAllReplyComments(GetReplyCommentRequest request)
        {
            var query = from c in _context.Comments
                        where c.replyId == request.commentId
                        join u in _context.Users on c.userId equals u.userId
                        select new { c, u };

            var comment = await query.Select(x => new ListComments()
            {
                postId = x.c.postId,
                userId = x.c.userId,
                commentId = x.c.commentId,
                replyId = x.c.replyId,
                Comment = x.c.Comment,
                Count = x.c.Count,
                Open = false,
                Name = x.u.Name,
                Image = x.u.Image
            }).ToListAsync();

            var result = new CommentModel<ListComments>()
            {
                data = comment
            };

            return result;
        }

        public async Task<Comments> GetById(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            return comment;
        }
    }
}
