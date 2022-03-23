using LikesAndDislikes.Models;
using LikesAndDislikes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LikesAndDislikes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(CreateAccountModel create)
        {
            if (ModelState.IsValid)
            {
                UserModel userModelCreate = new(create.Username, create.Password);

                AccountsModel.CreateUser(userModelCreate);
                return RedirectToAction("Profile");
            }
            else return View();
        }

        public IActionResult Profile(string? user)
        {
            if (user == null) return View();

            if (!AccountsModel.SearchUser(user)) return RedirectToAction("UserNotFound");
            else if (AccountsModel.DisplayContent(user) == null) return RedirectToAction("AddItem");
            else
            {
                ViewData["User"] = user;
                return View();
            }
        }

        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddItemModel content)
        {
            if (ModelState.IsValid)
            {
                UserModel userModelAdd = new(content.Username, content.Password);

                if (AccountsModel.ConfirmUser(userModelAdd))
                {
                    ItemModel itemModelAdd = new(content.Action, content.Option, content.Choice);

                    if (AccountsModel.AddToUser(userModelAdd.Username, itemModelAdd)) return RedirectToAction("Profile");
                    else return View(); // Hade för avsikt att lägga till specifikt felmeddelande, men det glömdes bort och nu har tiden runnit ut.
                }
                else return View(); // Hade för avsikt att lägga till specifikt felmeddelande, men det glömdes bort och nu har tiden runnit ut.
            }
            else return View();
        }

        public IActionResult UserNotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}