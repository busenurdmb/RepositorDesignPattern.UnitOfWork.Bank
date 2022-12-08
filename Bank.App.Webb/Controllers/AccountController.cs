using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Data.Interfaces;
using Bank.App.Webb.Data.Repositories;
using Bank.App.Webb.Data.UnitOfWork;
using Bank.App.Webb.Mapping;
using Bank.App.Webb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Webb.Controllers
{
  
    public class AccountController : Controller
    {

        //private readonly IApplicationUserRepository _appliccationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper  _accountMapper;

        //public AccountController( IApplicationUserRepository appliccationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository)
        //{

        //    _appliccationUserRepository = appliccationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //}
        //private readonly IGenericRepository<Account> _accountRepository;
        //private readonly IGenericRepository<ApplicationUser> _userRepository;
        //public AccountController(IGenericRepository<Account> accountRepository, IGenericRepository<ApplicationUser> userRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _userRepository = userRepository;
        //}

        private readonly IUow _uow;
        private readonly IUserMapper _userMapper;


        public AccountController(IUow uow, IUserMapper userMapper = null)
        {
            _uow = uow;
            _userMapper = userMapper;
        }
       
      
            public IActionResult Create(int id)
        {
            //var userInfo = _userMapper.MapToUserList( _appliccationUserRepository.GetByID(id));
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel
            {
                ApplicationUserId = userInfo.ApplicationUserId,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            // _accountRepository.Create(_accountMapper.Map(model));
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            });
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        //[AllowAnonymous]
         public IActionResult GetByUserId(int userıd)
        {
            
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts=  query.Where(x => x.ApplicationUserId == userıd).ToList();
            var user = _uow.GetRepository<ApplicationUser>().GetById(userıd);
            ViewBag.Fullname = user.Name + " " + user.Surname;
            var list = new List<AccountListModel>();

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id

                }) ;
            }
            return View(list);
            //var list = _accountRepository.GetById(id);
        }
        [HttpGet]
        public IActionResult SendMoney(int accountıd)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();

            var accounts = query.Where(x => x.Id != accountıd).ToList();
           
            var list = new List<AccountListModel>();
            ViewBag.Sender = accountıd;
            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id

                });
            }
           
            return View(new SelectList(list,"Id", "AccountNumber"));
        }
        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel Model)
        {
            //Unit Of Work
            var senderaccaount = _uow.GetRepository<Account>().GetById(Model.SenderId);
            senderaccaount.Balance -= Model.Amount;
            _uow.GetRepository<Account>().Update(senderaccaount);
            
            var account = _uow.GetRepository<Account>().GetById(Model.AccountId);
            account.Balance += Model.Amount;
            _uow.GetRepository<Account>().Update(account);

            _uow.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
