

using Bank.App.Webb.Data.Entities;
using System.Collections.Generic;

namespace Bank.App.Webb.Data.Interfaces
{
   public  interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetByID(int id);
        void Create(ApplicationUser user);
    }
}
