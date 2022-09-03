using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    replyId = table.Column<int>(nullable: false),
                    postId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentId);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    friendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendId1 = table.Column<int>(nullable: false),
                    FriendId2 = table.Column<int>(nullable: false),
                    IsFriend = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.friendId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId1 = table.Column<int>(nullable: false),
                    userId2 = table.Column<int>(nullable: false),
                    postId = table.Column<int>(nullable: false),
                    Watch = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.notificationId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    postId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Leter = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Home = table.Column<string>(nullable: false),
                    Word = table.Column<string>(nullable: false),
                    Relation = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "commentId", "Comment", "Count", "postId", "replyId", "userId" },
                values: new object[,]
                {
                    { 1, "Liver vô địch", 1, 1, 0, 1 },
                    { 2, "Kèo căng", 0, 1, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "friendId", "FriendId1", "FriendId2", "IsFriend" },
                values: new object[,]
                {
                    { 1, 1, 3, false },
                    { 2, 4, 1, true },
                    { 3, 4, 2, true }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "messageId", "Message", "Name", "RoomId" },
                values: new object[,]
                {
                    { 1, "hello", "The Wall", 2 },
                    { 2, "khoe chu", "Quang Linh", 2 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "notificationId", "Watch", "postId", "userId1", "userId2" },
                values: new object[] { 1, false, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Image", "Leter", "Like", "Title", "userId" },
                values: new object[,]
                {
                    { 1, "cde", "Trận chung kết", 0, "Champion League", 2 },
                    { 2, "ghi", "Ta sẽ trở thành vua hải tặc", 0, "Laugh Tale", 3 },
                    { 3, "gkl", "Dự án trang trại", 0, "Team châu phi", 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "Date", "Home", "Image", "Name", "Password", "Relation", "Username", "Word" },
                values: new object[,]
                {
                    { 1, "09/05/2003", "Thanh Hóa", "https://yt3.ggpht.com/ytc/AKedOLQC7VSmgZqXr4zMng24lu62_yMTgF4XgK_3MbSW=s900-c-k-c0x00ffffff-no-rj", "The Wall", "TheWall123", "Độc thân", "TheWall", "ĐH Công Nghiệp Hà Nội" },
                    { 2, "26/12/2002", "Hà Nội", "https://www.inlogo.vn/vnt_upload/File/Image/51qwJMbFL2L_SX425__1.jpg", "Liverpool", "Liverpool123", "Đang hẹn hò", "Liverpool", "ĐH Bách Khoa Hà Nội" },
                    { 3, "22/07/2001", "Đà Nẵng", "https://symbols.vn/wp-content/uploads/2022/01/Hinh-One-Piece-Chibi-Cute-cuc-dang-yeu-cute.png", "One Piece", "OnePiece123", "Đang hẹn hò", "OnePiece", "Tập Đoàn VinGroup" },
                    { 4, "01/01/2000", "Nghệ An", "https://yt3.ggpht.com/ytc/AKedOLR9OE6wZfxH1MndE9YZOzpWHj92ifRwsMQgHTk2QA=s900-c-k-c0x00ffffff-no-rj", "Quang Linh", "QuangLinh123", "Độc thân", "QuangLinh", "Angola" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
