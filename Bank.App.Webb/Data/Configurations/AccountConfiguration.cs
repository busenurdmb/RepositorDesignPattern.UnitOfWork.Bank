using Bank.App.Webb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();

            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Balance).IsRequired();

          //  builder.HasOne(a => a.ApplicationUser).WithMany(x => x.Accounts).HasForeignKey(x => x.ApplicationUserId);



        }
    }
}
