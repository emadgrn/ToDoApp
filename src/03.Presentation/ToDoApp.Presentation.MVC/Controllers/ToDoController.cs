using Microsoft.AspNetCore.Mvc;
using ToDoApp.Domain.ApplicationServices.ToDo;
using ToDoApp.Domain.Core.CategoryAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;
using ToDoApp.Domain.Services.Category;
using ToDoApp.Presentation.MVC.Database;

namespace ToDoApp.Presentation.MVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoAppService _toDoAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ToDoController(ILogger<ToDoController> logger, IToDoAppService toDoAppService, ICategoryAppService categoryAppService)
        {
            _logger = logger;
            _toDoAppService = toDoAppService;
            _categoryAppService = categoryAppService;
        }


        public IActionResult Index(string searchTerm, string sortOrder)
        {
            var result = _toDoAppService.GetUserTasks(InMemoryDatabase.OnlineUser!.Id, searchTerm, sortOrder);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View();
            }
            else
            {
                return View(result.Data);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryAppService.GetCategories();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateToDoDto model)
        {
            model.UserId = InMemoryDatabase.OnlineUser!.Id;
            var result=_toDoAppService.CreateToDo(model);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _toDoAppService.DeleteToDo(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Done(int id)
        {
            _toDoAppService.MarkAsDone(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NotDone(int id)
        {
            _toDoAppService.MarkAsNotDone(id);

            return RedirectToAction("Index");
        }
    }
}
