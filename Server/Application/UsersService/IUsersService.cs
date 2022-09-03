using Server.Application.Catalog.Dtos;
using Server.Application.Catalog.Dtos.User;
using Server.Application.Catalog.Profile;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.UsersService
{
    public interface IUsersService
    {
        Task<List<CreateUser>> GetAll();
        Task<CreateUser> GetLoginUser(LoginRequest request);
        Task<Users> GetUserID(int userId);
        Friends GetFriend(int user, int userId);
        Task<int> RegisterUser(RegisterRequest request);
    }
}
