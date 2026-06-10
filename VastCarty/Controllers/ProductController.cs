using Microsoft.AspNetCore.Mvc;

namespace VastCarty.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
