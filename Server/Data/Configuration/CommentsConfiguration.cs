using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.commentId);

            builder.Property(x => x.userId).IsRequired(true);

            builder.Property(x => x.Comment).IsRequired(true);

            builder.Property(x => x.postId).IsRequired(true);

            builder.Property(x => x.replyId).IsRequired(true);

            builder.Property(x => x.Count).IsRequired(true);

        }
    }
}
