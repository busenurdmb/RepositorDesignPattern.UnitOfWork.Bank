﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Data.Entities
{
    public class ApplicationUser
    {
        public int ApplicationUserId{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
