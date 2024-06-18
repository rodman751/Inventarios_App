using Microsoft.AspNetCore.Mvc;

namespace Inventario.MVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
