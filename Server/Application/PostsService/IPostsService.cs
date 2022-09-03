using Server.Application.Catalog.Posts;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.PostsService
{
    public interface IPostsService
    {
        Task<int> Create(PostsCreateRequest resquest);
        Task<Posts> GetById(int postId);
        Task<PageModel<ListPosts>> GetAllPaging(GetPagingRequest request);
        Task<int> Delete(int postId);
        Task<PageModel<ListPosts>> GetFilterPaging(GetFilterRequest request);
        Task<int> PostUpdateRequest(UpdateRequest request);
        Task<ListPosts> GetShowPost(GetPostIdRequest request);
    }
}
