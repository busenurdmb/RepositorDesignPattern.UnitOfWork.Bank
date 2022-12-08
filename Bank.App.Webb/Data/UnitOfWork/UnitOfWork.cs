using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Interfaces;
using Bank.App.Webb.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.UnitOfWork
{
    public class UnitOfWork:IUow
    {
        private readonly BankContext _bankContext;

        public UnitOfWork(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public IGenericRepository<T> GetRepository<T>() where T:class,new()
        {
            return new GenericRepository<T>(_bankContext);
        }

        public void SaveChanges()
        {
            _bankContext.SaveChanges();
        }
    }
}
