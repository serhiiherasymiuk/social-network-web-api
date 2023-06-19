using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Infrastructure.Configurations
{
    public class IndividualChatConfiguration : IEntityTypeConfiguration<IndividualChat>
    {
        public void Configure(EntityTypeBuilder<IndividualChat> builder)
        {
            builder
                .HasMany(i => i.Messages)
                .WithOne(m => m.IndividualChat);

            builder
                .HasOne(i => i.User1)
                .WithMany()
                .HasForeignKey(i => i.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.User2)
                .WithMany()
                .HasForeignKey(i => i.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
