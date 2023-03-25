using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class GroupChatMessageConfiguration : IEntityTypeConfiguration<GroupChatMessage>
    {
        public void Configure(EntityTypeBuilder<GroupChatMessage> builder)
        {
            builder
                .HasOne(i => i.Sender)
                .WithMany(s => s.GroupChatMessages);
            builder
                .HasOne(i => i.GroupChat)
                .WithMany(i => i.Messages);
        }
    }
}
