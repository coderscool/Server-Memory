using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class FriendsConfiguration : IEntityTypeConfiguration<Friends>
    {
        public void Configure(EntityTypeBuilder<Friends> builder)
        {
            builder.ToTable("Friends");

            builder.HasKey(x => x.friendId);

            builder.Property(x => x.FriendId1).IsRequired(true);

            builder.Property(x => x.FriendId2).IsRequired(true);

            builder.Property(x => x.IsFriend).IsRequired(true);
        }
    }
}
