using Server.Application.Catalog.Comments;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.CommentService
{
    public interface ICommentService
    {
        Task<int> CreateComment(CommentRequest request);
        Task<CommentModel<ListComments>> GetAllComments(GetCommentRequest request);
        Task<CommentModel<ListComments>> GetAllReplyComments(GetReplyCommentRequest request);
        Task<int> Delete(int postId);
        Task<Comments> GetById(int commentId);
    }
}
