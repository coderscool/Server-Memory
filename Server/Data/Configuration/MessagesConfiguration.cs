using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class MessagesConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(x => x.messageId);

            builder.Property(x => x.Message).IsRequired(false);

            builder.Property(x => x.Name).IsRequired(false);

            builder.Property(x => x.RoomId).IsRequired(true);
        }
    }
}
