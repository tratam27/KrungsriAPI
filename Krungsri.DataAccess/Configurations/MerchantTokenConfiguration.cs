using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class MerchantTokenConfiguration : IEntityTypeConfiguration<MerchantTokenAccess>
    {
        public void Configure(EntityTypeBuilder<MerchantTokenAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("MerchantToken");
            builder.Property(e => e.Id);
            builder.Property(e => e.RefreshToken);
            builder.HasOne(a => a.Merchant).WithOne(b => b.MerchantToken).HasForeignKey<MerchantTokenAccess>(a => a.MerchantId);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
