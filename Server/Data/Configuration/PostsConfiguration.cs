using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class PostsConfiguration : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.postId);

            builder.Property(x => x.Image).IsRequired(true);

            builder.Property(x => x.Leter).IsRequired(true);

            builder.Property(x => x.Title).IsRequired(true);

            builder.Property(x => x.userId).IsRequired(true);

            builder.Property(x => x.Like).IsRequired(true);
        }
    }
}
