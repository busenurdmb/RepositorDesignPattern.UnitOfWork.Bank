using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext contex)
        {
            _context = contex;
        }
        public List<Account> GetAll()
        {
           //return _context.accounts.ToList();

            return _context.Set<Account>().ToList();
        }
        //public Account GetByID(int id)
        //{
        //    return _context.accounts.SingleOrDefault(x => x.Id == id);
        //}
        public void Create(Account account)
        {
            _context.accounts.Add(account);
           // _context.Set<Account>().Add(account);
            _context.SaveChanges();
        }
        public void remove(Account account)
        {
            _context.Set<Account>().Remove(account);
            _context.SaveChanges();
        }
    }
}                                                    
