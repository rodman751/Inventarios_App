using Microsoft.AspNetCore.Mvc;

namespace Inventario.MVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
