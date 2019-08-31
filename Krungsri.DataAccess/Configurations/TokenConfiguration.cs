using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<TokenAccess>
    {
        public void Configure(EntityTypeBuilder<TokenAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Token");
            builder.Property(e => e.Id);
            builder.Property(e => e.RefreshToken);
            builder.HasOne(a => a.User).WithOne(b => b.Token).HasForeignKey<TokenAccess>(a => a.UserId);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
