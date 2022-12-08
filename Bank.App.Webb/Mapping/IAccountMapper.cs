using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Mapping
{
   public  interface IAccountMapper
    {
        Account Map(AccountCreateModel model);
    }
}
