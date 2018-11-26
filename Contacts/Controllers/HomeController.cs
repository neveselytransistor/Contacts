
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ContactList", "Contact");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}