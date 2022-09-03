using Microsoft.EntityFrameworkCore;
using Server.Application.Catalog.Dtos;
using Server.Application.Catalog.Dtos.User;
using Server.Application.Catalog.Profile;
using Server.Data.EF;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly ServerDbContext _context;
        public UsersService(ServerDbContext context)
        {
            _context = context;
        }
        public async Task<List<CreateUser>> GetAll()
        {
            var query = from u in _context.Users
                        select new { u };
            var data = await query.Select(x => new CreateUser()
            {
                userId = x.u.userId,
                Name = x.u.Name,
                Home = x.u.Home,
                Word = x.u.Word,
                Relation = x.u.Relation,
                Date = x.u.Date,
                Image = x.u.Image,
                Success = true
            }).ToListAsync();
            return data;
        }

        public Friends GetFriend(int user, int userId )
        {
            var friend = _context.Friends.Where(x => (x.FriendId1 == user && x.FriendId2 == userId) || (x.FriendId1 == userId && x.FriendId2 == user)).FirstOrDefault();
            if (friend == null)
            {
                var dt = new Friends()
                {
                    friendId = 0,
                    FriendId1 = 0,
                    FriendId2 = 0,
                    IsFriend = false
                };
                return dt;
            }
            var data = new Friends()
            {
                friendId = friend.friendId,
                FriendId1 = friend.FriendId1,
                FriendId2 = friend.FriendId2,
                IsFriend = friend.IsFriend
            };

            return data;
        }

        public async Task<CreateUser> GetLoginUser(LoginRequest request)
        {
            var result = _context.Users.Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();
            if (result == null)
            {
                var datas = new CreateUser()
                {
                    Success = false
                };
                return datas;
            }
            var data = new CreateUser()
            {
                userId = result.userId,
                Name = result.Name,
                Home = result.Home,
                Date = result.Date,
                Image = result.Image,
                Word = result.Word,
                Relation = result.Relation,
                Success = true
            };
            return data;
        }

        public async Task<Users> GetUserID(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            var data = new Users()
            {
                userId = user.userId,
                Name = user.Name,
                Home = user.Home,
                Word = user.Word,
                Date = user.Date,
                Image = user.Image,
                Relation = user.Relation
            };

            return data;
        }

        public async Task<int> RegisterUser(RegisterRequest request)
        {
            var user = new Users()
            {
                Username = request.Username,
                Password = request.Password,
                Name = request.Name,
                Word = request.Word,
                Home = request.Home,
                Relation = request.Relation,
                Date = request.Date,
                Image = request.Image
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.userId;
        }
    }
}
