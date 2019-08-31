using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<AdminAccess>
    {
        public void Configure(EntityTypeBuilder<AdminAccess> builder)
        {
            builder.HasKey(x => x.AdminId);
            builder.ToTable("Admin");
            builder.Property(e => e.AdminId);
            builder.Property(e => e.Name);
            builder.Property(e => e.UserName);
            builder.Property(e => e.BookBank);
            builder.Property(e => e.Salt);
            builder.Property(e => e.Password);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
