using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Mapping
{
    //accountcreatemodeli accounta çevirecek
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
               ApplicationUserId=model.ApplicationUserId,
                Balance = model.Balance
             };
        }
    }
}
