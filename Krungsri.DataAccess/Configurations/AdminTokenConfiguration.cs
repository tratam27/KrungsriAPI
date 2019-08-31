using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class AdminTokenConfiguration : IEntityTypeConfiguration<AdminTokenAccess>
    {
        public void Configure(EntityTypeBuilder<AdminTokenAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AdminToken");
            builder.Property(e => e.Id);
            builder.Property(e => e.RefreshToken);
            builder.HasOne(a => a.Admin).WithOne(b => b.AdminToken).HasForeignKey<AdminTokenAccess>(a => a.AdminId);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
