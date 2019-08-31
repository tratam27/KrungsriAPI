using Krungsri.DataAccess.Configurations;
using Krungsri.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Context
{
    public class KrungsriContext : DbContext
    {
        public KrungsriContext(DbContextOptions options)
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=Krungsri;trusted_connection=true;");
            }
        }
        public DbSet<UserAccess> users { get; set; }
        public DbSet<TokenAccess> tokens { get; set; }
        public DbSet<OtpAccess> oTPs { get; set; }
        public DbSet<AdminAccess> admins { get; set; }        
        public DbSet<AdminTransactionAccess> adminTransactions { get; set; }
        public DbSet<AdminTokenAccess> adminTokens { get; set; }
        public DbSet<MerchantAccess> merchants { get; set; }        
        public DbSet<MerchantTransactionAccess> merchantTransactions { get; set; }
        public DbSet<MerchantTokenAccess> merchantTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new OTPConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantTokenConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTokenConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTransactionConfiguration());
        }
    }

}
