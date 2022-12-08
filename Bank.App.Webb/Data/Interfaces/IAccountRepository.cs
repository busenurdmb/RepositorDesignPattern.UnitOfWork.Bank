using Bank.App.Webb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
