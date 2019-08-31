using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserAccess>
    {
        public void Configure(EntityTypeBuilder<UserAccess> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.ToTable("User");
            builder.Property(e => e.UserId);
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.Email);
            builder.Property(e => e.Gender);
            builder.Property(e => e.Balance);
            builder.Property(e => e.Birthdate);
            builder.Property(e => e.CreateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.UpdateDateTime).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        }
    }
}
