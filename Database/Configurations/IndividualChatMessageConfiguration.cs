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
    public class IndividualChatMessageConfiguration : IEntityTypeConfiguration<IndividualChatMessage>
    {
        public void Configure(EntityTypeBuilder<IndividualChatMessage> builder)
        {
            builder
                .HasOne(i => i.Sender)
                .WithMany(s => s.IndividualChatMessages);
            builder
                .HasOne(i => i.IndividualChat)
                .WithMany(i => i.Messages);
        }
    }
}
