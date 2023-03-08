using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class LikeConfigurations : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder
                .HasOne(l => l.User)
                .WithMany(u => u.Likes);
            builder
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes);
        }
    }
}
