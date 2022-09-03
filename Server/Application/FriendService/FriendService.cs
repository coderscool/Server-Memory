using Microsoft.EntityFrameworkCore;
using Server.Application.Catalog.Friends;
using Server.Data.EF;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly ServerDbContext _context;
        public FriendService(ServerDbContext context)
        {
            _context = context;
        }

        public async Task<int> AcceptFriend(int friendId)
        {
            var friend = await _context.Friends.FindAsync(friendId);
            if (friend == null) throw new Exception("cannot find a pictur");
            friend.IsFriend = true;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateFriend(FriendQuery resquest)
        {
            var friend = new Friends()
            {
                FriendId1 = resquest.userId,
                FriendId2 = resquest._local,
                IsFriend = false
            };
            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();
            return friend.friendId;
        }

        public async Task<int> DeleteFriend(int friendId)
        {
            var friend = await _context.Friends.FindAsync(friendId);
            _context.Friends.Remove(friend);
            return await _context.SaveChangesAsync();
        }

        public async Task<Friends> GetByIdFriend(int friendId)
        {
            var friend = await _context.Friends.FindAsync(friendId);
            return friend;
        }

        public async Task<ListInforFriends<ListFriends>> GetListFriends(GetFriends resquest)
        {

            var query = from f in _context.Friends
                        where (f.FriendId1 == resquest.myId && f.IsFriend == true) || (f.FriendId2 == resquest.myId && f.IsFriend == true)
                        join u in _context.Users on f.FriendId1 equals u.userId into m
                        from u in m.DefaultIfEmpty()
                            //where u.userId != request.myId
                        join k in _context.Users on f.FriendId2 equals k.userId into n
                        from k in n.DefaultIfEmpty()
                            //where k.userId != request.myId
                        select new { f, u, k };

            var data = await query.Select(x => new ListFriends()
            {
                room = x.f.friendId.ToString(),
                userId = (x.u.userId == resquest.myId) ? x.k.userId : x.u.userId,
                user = (x.u.userId == resquest.myId) ? x.k.Name : x.u.Name,
                image = (x.u.userId == resquest.myId) ? x.k.Image : x.u.Image
                //Name1 = x.k.Name,
                //userId1 = x.k.userId
            }).ToListAsync();

            var result = new ListInforFriends<ListFriends>()
            {
                Data = data
            };
            return result;
        }

        public async Task<MessageMakeFriend> Message(FriendQuery request)
        {
            var friend = _context.Friends.Where(x => (x.FriendId1 == request._local && x.FriendId2 == request.userId) || (x.FriendId1 == request.userId && x.FriendId2 == request._local)).FirstOrDefault();

            if(friend != null)
            {
                if(friend.IsFriend == true)
                {
                    var data = new MessageMakeFriend()
                    {
                        Id = friend.friendId,
                        MessageMF = "Ban be"
                    };
                    return data;
                }
                else if(friend.IsFriend == false && friend.FriendId1 == request._local)
                {
                    var data = new MessageMakeFriend()
                    {
                        Id = friend.friendId,
                        MessageMF = "Chap nhan ket ban"
                    };
                    return data;
                }
                else if(friend.IsFriend == false && friend.FriendId2 == request._local)
                {
                    var data = new MessageMakeFriend()
                    {
                        Id = friend.friendId,
                        MessageMF = "Da gui ket ban"
                    };
                    return data;
                }
            }

            var result = new MessageMakeFriend()
            {
                MessageMF = "Ket ban"
            };
            return result;
        }
    }
}
