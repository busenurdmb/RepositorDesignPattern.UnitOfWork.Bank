using Bank.App.Webb.Data.Context;
using Bank.App.Webb.Data.Entities;
using Bank.App.Webb.Data.Interfaces;
using Bank.App.Webb.Data.Repositories;
using Bank.App.Webb.Data.UnitOfWork;
using Bank.App.Webb.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.App.Webb.Controllers
{
    public class HomeController : Controller
    {
        
       // private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;

       public HomeController(/* IApplicationUserRepository applicationUserRepository,*/ IUserMapper userMapper, IUow uow)
        {
          
            //_applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _uow = uow;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            var list = _userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll());
            return View(list);
        }
    }
}
