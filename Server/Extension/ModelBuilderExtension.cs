using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>().HasData(
                 new Posts() { postId = 1, userId = 2, Title = "Champion League", Leter = "Trận chung kết", Image = "cde", Like = 0 },
                 new Posts() { postId = 2, userId = 3, Title = "Laugh Tale", Leter = "Ta sẽ trở thành vua hải tặc", Image = "ghi", Like = 0 },
                 new Posts() { postId = 3, userId = 4, Title = "Team châu phi", Leter = "Dự án trang trại", Image = "gkl", Like = 0 }
                 );

            modelBuilder.Entity<Comments>().HasData(
                new Comments() { commentId = 1, postId = 1, userId = 1, replyId = 0 ,Comment = "Liver vô địch", Count = 1 },
                new Comments() { commentId = 2, postId = 1, userId = 3, replyId = 1 ,Comment = "Kèo căng", Count= 0 }
                );

            modelBuilder.Entity<Messages>().HasData(
                new Messages() { messageId = 1, Name = "The Wall", Message = "hello", RoomId = 2 },
                new Messages() { messageId = 2, Name = "Quang Linh", Message = "khoe chu", RoomId = 2 }
                );

            modelBuilder.Entity<Friends>().HasData(
                new Friends() { friendId = 1, FriendId1 = 1, FriendId2 = 3, IsFriend = false },
                new Friends() { friendId = 2, FriendId1 = 4, FriendId2 = 1, IsFriend = true },
                new Friends() { friendId = 3, FriendId1 = 4, FriendId2 = 2, IsFriend = true }
                );

            modelBuilder.Entity<Users>().HasData(
                new Users() { userId = 1, Name = "The Wall", Username = "TheWall", Password = "TheWall123", Date = "09/05/2003", Home = "Thanh Hóa", Word = "ĐH Công Nghiệp Hà Nội", Relation = "Độc thân", Image = "https://yt3.ggpht.com/ytc/AKedOLQC7VSmgZqXr4zMng24lu62_yMTgF4XgK_3MbSW=s900-c-k-c0x00ffffff-no-rj" },
                new Users() { userId = 2, Name = "Liverpool", Username = "Liverpool", Password = "Liverpool123", Date = "26/12/2002", Home = "Hà Nội", Word = "ĐH Bách Khoa Hà Nội", Relation = "Đang hẹn hò", Image = "https://www.inlogo.vn/vnt_upload/File/Image/51qwJMbFL2L_SX425__1.jpg" },
                new Users() { userId = 3, Name = "One Piece", Username = "OnePiece", Password = "OnePiece123", Date = "22/07/2001", Home = "Đà Nẵng", Word = "Tập Đoàn VinGroup", Relation = "Đang hẹn hò", Image = "https://symbols.vn/wp-content/uploads/2022/01/Hinh-One-Piece-Chibi-Cute-cuc-dang-yeu-cute.png" },
                new Users() { userId = 4, Name = "Quang Linh", Username = "QuangLinh", Password = "QuangLinh123", Date = "01/01/2000", Home = "Nghệ An", Word = "Angola", Relation = "Độc thân", Image = "https://yt3.ggpht.com/ytc/AKedOLR9OE6wZfxH1MndE9YZOzpWHj92ifRwsMQgHTk2QA=s900-c-k-c0x00ffffff-no-rj" }
                );

            modelBuilder.Entity<Notifications>().HasData(
               new Notifications() { notificationId = 1, postId = 1, userId1 = 1, userId2 = 3, Watch = false }
               );
        }
    }
}
