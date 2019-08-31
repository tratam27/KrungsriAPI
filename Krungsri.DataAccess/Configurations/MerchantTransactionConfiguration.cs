using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class MerchantTransactionConfiguration : IEntityTypeConfiguration<MerchantTransactionAccess>
    {
        public void Configure(EntityTypeBuilder<MerchantTransactionAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("MerchantTransaction");
            builder.Property(e => e.Id);
            builder.Property(e => e.MoneyAmount);
            builder.Property(e => e.Ref);
            builder.HasOne(e => e.Merchant).WithMany(b => b.MerchantTransactions).HasForeignKey(e => e.MerchantId);
            builder.HasOne(e => e.User).WithMany(b => b.MerchantTransactions).HasForeignKey(e => e.UserId);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }    
}
