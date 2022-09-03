using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(x => x.notificationId);

            builder.Property(x => x.userId1).IsRequired(true);

            builder.Property(x => x.userId2).IsRequired(true);

            builder.Property(x => x.postId).IsRequired(true);

            builder.Property(x => x.Watch).IsRequired(true);

        }
    }
}
