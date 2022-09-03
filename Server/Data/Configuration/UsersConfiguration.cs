using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.userId);

            builder.Property(x => x.Username).IsRequired(true);

            builder.Property(x => x.Password).IsRequired(true);

            builder.Property(x => x.Name).IsRequired(true);

            builder.Property(x => x.Home).IsRequired(true);

            builder.Property(x => x.Image).IsRequired(true);

            builder.Property(x => x.Word).IsRequired(true);

            builder.Property(x => x.Date).IsRequired(true);

            builder.Property(x => x.Relation).IsRequired(true);
        }
    }
}
