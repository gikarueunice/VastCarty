using Microsoft.AspNetCore.Mvc;

namespace VastCarty.Controllers
{
    public class AuthController : Controller
    {
        public AuthController()
        {

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register()
        {
            return View(Model);
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
