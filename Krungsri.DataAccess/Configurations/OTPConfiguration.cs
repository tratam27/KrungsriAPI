using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class OTPConfiguration : IEntityTypeConfiguration<OtpAccess>
    {
        public void Configure(EntityTypeBuilder<OtpAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("OTP");
            builder.Property(e => e.Id);
            builder.Property(e => e.Otp);
            builder.Property(e => e.Ref);
            builder.Property(e => e.Email);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
