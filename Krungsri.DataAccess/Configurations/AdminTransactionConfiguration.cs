using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class AdminTransactionConfiguration : IEntityTypeConfiguration<AdminTransactionAccess>
    {
        public void Configure(EntityTypeBuilder<AdminTransactionAccess> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AdminTransaction");
            builder.Property(e => e.Id);
            builder.Property(e => e.MoneyAmount);
            builder.Property(e => e.Ref);
            builder.HasOne(e => e.Admin).WithMany(b => b.AdminTransactions).HasForeignKey(e => e.AdminId);
            builder.HasOne(e => e.User).WithMany(b => b.AdminTransactions).HasForeignKey(e => e.UserId);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
