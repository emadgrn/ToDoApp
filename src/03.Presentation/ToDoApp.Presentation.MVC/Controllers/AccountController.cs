using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain.Core.UserAgg.Contracts;
using ToDoApp.Domain.Core.UserAgg.DTOs;
using ToDoApp.Domain.Services.User;
using ToDoApp.Presentation.MVC.Database;
using ToDoApp.Presentation.MVC.Models;

namespace ToDoApp.Presentation.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAppService _userAppService;

        public AccountController(ILogger<AccountController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginResult = _userAppService.Login(model.Username, model.Password);

            if (loginResult.IsSuccess)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data!.Id,
                    Username = loginResult.Data.Username,
                    Fullname = loginResult.Data.Fullname
                };

                return RedirectToAction("Index","ToDo");
            }
            else
            {
                ViewBag.Error = loginResult.Message;
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var userModel = new CreateUserDto()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Username = model.Username,
            };

            var registerResult = _userAppService.Register(userModel);

            if (registerResult.IsSuccess)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser
                {
                    Id = registerResult.Data!.Id,
                    Username = registerResult.Data.Username,
                    Fullname = registerResult.Data.Fullname
                };

                return RedirectToAction("Index", "ToDo");
            }
            else
            {
                ViewBag.Error = registerResult.Message;
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            InMemoryDatabase.OnlineUser = null;
            return RedirectToAction("Login");
        }
    }
}
