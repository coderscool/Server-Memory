using Server.Application.Catalog.Posts;
using Server.Application.Catalog.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.ProfileService
{
    public interface IProfileService
    {
        Task<ProfileModel<ListPosts>> GetPostsProfile(PostsQuery request);
    }
}