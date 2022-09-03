using Server.Application.Catalog.Friends;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.FriendService
{
    public interface IFriendService
    {
        Task<MessageMakeFriend> Message(FriendQuery request);
        Task<int> CreateFriend(FriendQuery resquest);
        Task<Friends> GetByIdFriend(int postId);
        Task<ListInforFriends<ListFriends>> GetListFriends(GetFriends resquest);
        Task<int> DeleteFriend(int friendId);
        Task<int> AcceptFriend(int friendId);
    }
}
