using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace CRUD.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private static IRepository<Task> _taskRepository = new TaskRepository();
        private static IRepository<User> _userRepository = new UserRepository();

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("activeUser");
            if (user != null)
            {
                User activeUser = JsonSerializer.Deserialize<User>(user);
                ViewData["activeUserRole"] = activeUser.Role;
                //TODO: Verify if user is legit
                return View(_taskRepository.Entities);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            //TODO: Ensure unique IDS, and task doesn't not exist
            _taskRepository.Entities.Add(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _taskRepository.Entities.FirstOrDefault(t => t.Id == id);
            return View(taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            var taskToEdit = _taskRepository.Entities.FirstOrDefault(t => t.Id == task.Id);

            if (taskToEdit != null)
            {
                var taskIndex = _taskRepository.Entities.IndexOf(taskToEdit);
                _taskRepository.Entities[taskIndex].Name = task.Name;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (_userRepository.EntityExists(user))
            {
                user.Role = Role.HighUser;
                string userAsJson = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("activeUser", userAsJson);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
