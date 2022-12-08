using Bank.App.Webb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Surname).HasMaxLength(200);
            builder.Property(x => x.Surname).IsRequired();

            builder.HasMany(X => X.Accounts).WithOne(X => X.ApplicationUser).HasForeignKey(X => X.ApplicationUserId);
        }
    }
}
