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
    public class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
    {
        public void Configure(EntityTypeBuilder<GroupChat> builder)
        {
            builder
                .HasMany(g => g.Messages)
                .WithOne(m => m.GroupChat)
                .HasForeignKey(m => m.GroupChatId);
            builder
                .HasMany(g => g.Members)
                .WithMany(m => m.GroupChats);
        }
    }
}
