using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bank.App.Webb.Data.Repositories
{
    public class AppliccationUserRepository: IApplicationUserRepository
    {
        private readonly BankContext _context;

        public AppliccationUserRepository(BankContext context)
        {
           _context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.applicationUsers.ToList();
        }
        public ApplicationUser GetByID(int id)
        {
            return _context.applicationUsers.SingleOrDefault(x => x.ApplicationUserId == id);
        }
        public void Create(ApplicationUser user)
        {
            //İKİSİDE AYNNI
          //  var test = _context.applicationUsers;
           // var test2 = _context.Set<ApplicationUser>();

             _context.applicationUsers.Add(user);
            //_context.Set<ApplicationUser>().Add(user);
            _context.SaveChanges();
        }
        public void Remove(ApplicationUser user)
        {
            _context.Set<ApplicationUser>().Remove(user);
            _context.SaveChanges();
        }
    }
}
