using Bank.App.Webb.Data.Configurations;
using Bank.App.Webb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Context
{
    public class BankContext:DbContext
    {
        public DbSet<ApplicationUser>  applicationUsers { get; set; }
        public DbSet<Account>  accounts { get; set; }
        
        //BENİM DBCONTEXT classımı Geçmiş olduğum clasımı optionsı göndericem 
        //artık o onconfiguring methodu gibi çalışacak optionslarrı startupda vericez
        public BankContext(DbContextOptions<BankContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
