using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<MerchantAccess>
    {
        public void Configure(EntityTypeBuilder<MerchantAccess> builder)
        {
            builder.HasKey(x => x.MerchantId);
            builder.ToTable("Merchant");
            builder.Property(e => e.MerchantId);
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
