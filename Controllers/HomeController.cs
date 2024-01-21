using Microsoft.AspNetCore.Mvc;

namespace versta24.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List", "Order");
        }
    }
}
